using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameManager : IGameManager
    {
        public readonly IGameContext _context;
        private readonly INotifier _notifier;
        public event Action<Card, Player>? OnCardAddedToHand;
        public event Action<Card>? OnCardPlayed;
        public event Action<Card>? OnCardMovedToDiscardPile;
        public event Action<Card>? OnCardMovedToBoard;
        public event Action<Card>? OnCardMovedToBeforePlayer;
        public event Action<Card>? OnCardMovedToTimeOfDaySlot;
        public event Action<Item, Player>? OnItemAddToPlayer;
        public event Action<Player>? OnAddPointsToPlayer;
        public event Action<string>? OnMessagePrinted;


        public GameManager(IGameState gameState, IGameBoard gameBoard,
            List<Player> players, Deck deck, ItemManager items,
            INotifier notifier)
        {
            _context = new GameContext(
                gameState, gameBoard,
                    players, deck, items, this);
            _notifier = notifier;
        }
        public void PrintMessage(string message)
        {
            _notifier.Notify(message);
            OnMessagePrinted?.Invoke(message);
        }
        public void StartGame()
        {
            // Установка ночи в начале игры
            Card night = _context.Deck.TakeCardByName("Ночь")!;
            PutCardInTimeOfDaySlot(night);

            PrintMessage("Раздача карт.");
            DrawCardsToPlayersHand();

            var currentPlayer = _context.GameState.GetCurrentPlayer();
            PrintMessage($"{currentPlayer.Name} начинает ход первым.");


            PrintMessage("Игра началась!");
            Run();
        }

        public void DrawCardsToPlayersHand()
        {
            var players = _context.Players;
            var deck = _context.Deck;
            foreach (var player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                    var card = deck.DrawCard();
                    PutCardInPlayerHand(card!, player);
                }
            }
        }
        /// <summary>
        /// Пытается вытянуть карту из колоды, если она не пуста.
        /// </summary>
        /// <returns>Карта или null. БЕЗ ВЛАДЕЛЬЦА</returns>
        public Card? TryDrawCardFromDeck()
        {
            var deck = _context.Deck;
            var card = deck.DrawCard();
            if (card == null)
            {
                PrintMessage("В колоде не осталось карт");
                return null;
            }
            else if (deck.CardsRemaining == 1)
            {
                PrintMessage("В колоде осталась последняя карта");
                return card;
            }
            else
                return card;
        }
        public void Run()

        {
            while (!_context.GameState.IsGameOver)
            {
                GameCourse();
            }
        }
        public void GameCourse()
        {
            var gameState = _context.GameState;
            var player = _context.GameState.GetCurrentPlayer();

            PrintMessage($"Время суток {gameState.GetTimeOfday()}.");
            PrintMessage($"{player.Name} начинает ход.");


            // 1. Взять 1 карту
            DrawCard(player);
            // 2. Взять 1 предмет
            PlayItem(player);
            // 3. Разыграть карту
            PlayCard(player);

            // Активация всех поссивных эффектов в конце хода игрока
            ActivateAllPlayerPermanentCardEffects(player);

            gameState.NextTurn();
        }
        /// <summary>
        /// Взять 1 карту из колоды и передать игроку
        /// </summary>
        /// <param name="player"></param>
        public void DrawCard(Player player)
        {
            var cardFromDeck = TryDrawCardFromDeck();
            if (cardFromDeck != null)
            {
                PutCardInPlayerHand(cardFromDeck, player);
            }
        }
        /// <summary>
        /// Разыгрывание игроком предмета (По желанию)
        /// </summary>
        public void PlayItem(Player player)
        {
            PrintMessage("Выбор предмета Не работает!");
        }
        /// <summary>
        /// Разыгрывание игрком карты
        /// </summary>
        public void PlayCard(Player player)
        {
            if (player.Hand.Count == 0)
            {
                PrintMessage($"У игрока {player.Name} не осталось карт.");
                EndGame();
            }

            Card card = player.SelectCardInHand();
            player.RemoveCardFromHand(card);
            PrintMessage($"Игрок {player.Name} разыгрывает карту {card.Name}.");
            AddPointsToPlayer(player, card.Points);
            ActivateInstantCardEffect(card);
            MoveCardToItsPosition(card);
        }

        public void PlayCard(Card card)
        {
            var player = _context.GameState.GetCurrentPlayer();
            if (player.HasCard(card))
            {
                player.RemoveCardFromHand(card);
                PrintMessage($"Игрок {player.Name} разыгрывает карту {card.Name}.");
                AddPointsToPlayer(player, card.Points);
                ActivateInstantCardEffect(card);
                MoveCardToItsPosition(card);
            }
        }
        /// <summary>
        /// Активирует все постоянные эффекты активных карт игрока
        /// </summary>
        public void ActivateAllPlayerPermanentCardEffects(Player player)
        {
            var board = _context.GameBoard;
            var cards = board.GetCardsOnBoard(player);
            foreach (var card in cards)
                ActivatePermanentCardEffect(card);
        }
        /// <summary>
        /// Активируется мгновенный эффект карты
        /// </summary>
        public void ActivateInstantCardEffect(Card card)
        {
            if (card.Effect.Type == CardEffectTimeType.Instant)
                card.ActivateEffect(_context);
        }
        /// <summary>
        /// Активируется постоянный эффект карты
        /// </summary>
        public void ActivatePermanentCardEffect(Card card)
        {
            if (card.Effect.Type == CardEffectTimeType.PermanentAtTheEnd)
                card.ActivateEffect(_context);
        }
        /// <summary>
        /// Присвоение пользователю ПО
        /// </summary>
        /// <param name="player">Кому присвоить</param>
        /// <param name="points">Сколько ПО присвоить</param>
        public void AddPointsToPlayer(Player player, int points)
        {
            if (points > 0)
            {
                PrintMessage($"Игрок {player.Name} получает {points} ПО.");
                player.AddPoints(points);
                OnAddPointsToPlayer?.Invoke(player);
            }
        }
        public void MoveCardToItsPosition(Card card)
        {
            var board = _context.GameBoard;
            switch (card.PositionAfterPlay)
            {
                case (CardPosition.OnGameBoard):
                    {
                        PutCardOnBoard(card);
                        PrintMessage($"Карта {card.Name} была разыграна на стол.");
                        break;
                    }
                case (CardPosition.BeforePlayer):
                    {
                        PutCardBeforePlayer(card);
                        PrintMessage($"Карта {card.Name} была разыграна на стол перед игроком.");
                        break;
                    }
                case (CardPosition.Discarded):
                    {
                        PutCardToDiscardPile(card);
                        PrintMessage($"Карта {card.Name} была разыграна и сброшена.");
                        break;
                    }
                case (CardPosition.TimeOfDay):
                    {
                        PutCardInTimeOfDaySlot(card);
                        PrintMessage($"Карта {card.Name} была разыграна.");
                        break;
                    }
            }
        }
        public void PutCardToDiscardPile(Card card)
        {
            var board = _context.GameBoard;
            board.AddCardToDiscardPile(card);
            card.Position = CardPosition.Discarded;
            card.Owner = null;
            OnCardMovedToDiscardPile?.Invoke(card);
        }
        public void PutCardOnBoard(Card card)
        {
            var board = _context.GameBoard;
            board.AddCardOnBoard(card);
            card.Position = CardPosition.OnGameBoard;
            OnCardMovedToBoard?.Invoke(card);
        }
        public void PutCardBeforePlayer(Card card)
        {
            var board = _context.GameBoard;
            board.AddCardOnBoard(card); // Временно
            card.Position = CardPosition.BeforePlayer;
            OnCardMovedToBeforePlayer?.Invoke(card);
        }
        public void PutCardInPlayerHand(Card card, Player player)
        {
            player.AddCardToHand(card);
            card.Position = CardPosition.InHand;
            card.Owner = player;
            OnCardAddedToHand?.Invoke(card, player);
        }

        public void PutCardInTimeOfDaySlot(Card card)
        {
            var board = _context.GameBoard;
            board.SetTimeOfDaySlot(card);
            card.Position = CardPosition.TimeOfDay;
            OnCardMovedToTimeOfDaySlot?.Invoke(card);
        }
        public void PutItemInPlayerItemBag(Item item, Player player)
        {
            player.AddItemToItemBag(item);
            OnItemAddToPlayer?.Invoke(item, player);
        }
        public void EndGame()
        {
            _context.GameState.EndGame();
        }
    }
}
