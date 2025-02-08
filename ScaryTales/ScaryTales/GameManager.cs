using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameManager
    {
        private readonly IGameContext _context;
        private readonly INotifier _notifier;

        public GameManager(List<Player> players,
            Deck deck, ItemManager items, INotifier notifier)
        {
            _context = new GameContext(
                new GameState(players), new GameBoard(),
                    players, deck, items, this);
            _notifier = notifier;
        }
        public void PrintMessage(string message) => _notifier.Notify(message);
        public void StartGame()
        {
            PrintMessage("Раздача карт.");
            DrawCardsToPlayersHand();

            var currentPlayer = _context.GameState.GetCurrentPlayer();
            PrintMessage($"{currentPlayer.Name} начинает ход первым.");

            PrintMessage("Игра началась!");
            Run();
        }

        private void DrawCardsToPlayersHand()
        {
            var players = _context.Players;
            var deck = _context.Deck;
            foreach (var player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                    var card = deck.DrawCard();
                    player.AddCardToHand(card!);
                    card!.Position = CardPosition.InHand;
                }
            }
        }
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
        private void Run()

        {
            while(!_context.GameState.IsGameOver)
            {
                GameCourse();
            }
        }
        private void GameCourse()
        {
            var gameState = _context.GameState;
            var player = _context.GameState.GetCurrentPlayer();

            PrintMessage($"{player.Name} начинает ход.");
            // 1. Взять 1 карту
            DrawCard(player);
            // 2. Взять 1 предмет
            PlayItem(player);
            // 3. Разыграть карту
            PlayCard(player);

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
            CardEffectActivate(card);
            MoveCardToItsPosition(card);
        }
        /// <summary>
        /// Активируется эффект карты
        /// </summary>
        public void CardEffectActivate(Card card)
        {
            card.Effect.ApplyEffect(_context);
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
            }
        }
        public void PutCardToDiscardPile(Card card)
        {
            var board = _context.GameBoard;
            board.AddCardToDiscardPile(card);
            card.Position = CardPosition.Discarded;
        }
        public void PutCardOnBoard(Card card)
        {
            var board = _context.GameBoard;
            board.AddCardOnBoard(card);
            card.Position = CardPosition.OnGameBoard;
        }
        public void PutCardBeforePlayer(Card card)
        {
            var board = _context.GameBoard;
            board.AddCardOnBoard(card); // Временно
            card.Position = CardPosition.BeforePlayer;
        }
        public void PutCardInPlayerHand(Card card, Player player)
        {
            player.AddCardToHand(card);
            card.Position = CardPosition.InHand;
        }
        public void EndGame()
        {
            _context.GameState.EndGame();
        }
    }
}
