using ScaryTales.Abstractions;
using ScaryTales.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameBoard : IGameBoard
    {
        private List<Card> _cardsOnBoard;       // Карты, находящиеся на игровом столе
        private List<Card> _discardPile;        // Общая колода сброса


        public MessageHandler Output { get; set; } // Поле делегата для вывода сообщений
        public GameBoard(MessageHandler output)
        {
            _cardsOnBoard = new List<Card>();
            _discardPile = new List<Card>();
            Output = output;
        }

        // Метод для разыгрывания карты на стол
        public void PlayCardOnBoard(Card card)
        {
            card.Position = card.PositionAfterPlay;
            if (card.Position == CardPosition.OnGameBoard || card.Position == CardPosition.BeforePlayer)
            {
                _cardsOnBoard.Add(card);
                Output?.Invoke($"Карта {card.Name} была разыграна на стол.");
            }
        }

        // Метод для сброса карты (перемещение из игры на столе в колоду сброса)
        public void AddCardToDiscardPile(Card card)
        {
            card.Position = CardPosition.Discarded;
            _cardsOnBoard.Remove(card);
            _discardPile.Add(card);
            Output?.Invoke($"Карта {card.Name} была сброшена.");
        }

        // Метод для перемещения всех карт с игрового стола в колоду сброса
        public void MoveAllCardsToDiscardPile()
        {
            foreach (var card in _cardsOnBoard)
            {
                AddCardToDiscardPile(card);
            }
            _cardsOnBoard.Clear();
            Output?.Invoke("Все карты с игрового стола были сброшены.");
        }

        // Метод для отображения карт на игровом столе
        public void ShowCardsOnBoard()
        {
            if (_cardsOnBoard.Count == 0)
            {
                Output?.Invoke("Нет ни одной карты на столе.");
                return;
            }
            Output?.Invoke("Карты на игровом столе:");
            foreach (var card in _cardsOnBoard)
            {
                Output?.Invoke($"{card.Name} ({card.Type})");
            }
        }

        // Метод для отображения карт пользователя на столе
        public List<Card> GetPlayerCardsOnBoard(Player player)
        {
            var cards = new List<Card>();
            foreach (var card in _cardsOnBoard)
            {
                if (card.Owner == player)
                    cards.Add(card);
            }
            return cards;
        }

        // Метод для отображения карт в колоде сброса
        public void ShowDiscardPile()
        {
            Output?.Invoke("Карты в колоде сброса:");
            foreach (var card in _discardPile)
            {
                Output?.Invoke($"{card.Name} ({card.Type})");
            }
        }
        // Получение все разыгранных карт, лежащих на столе
        public List<Card> GetCardsOnBoard() => _cardsOnBoard;

        public List<Card> GetCardsOnBoardByType(CardType type)
        {
            return _cardsOnBoard.Where(x => x.Type == type).ToList();
        }

        // Получение количества карт на столе
        public int CardsOnBoardCount => _cardsOnBoard.Count;

        // Получение количества карт в колоде сброса
        public int DiscardPileCount => _discardPile.Count;
    }
}
