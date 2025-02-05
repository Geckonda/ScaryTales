using ScaryTales.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        private List<Card> _hand;            // Карты в руке игрока
        private Deck _deck;                  // Ссылка на основную колоду
        private GameBoard _gameBoard;        // Ссылка на игровое поле



        public MessageHandler Output { get; set; } // Поле делегата для вывода сообщений

        public Player(string name, Deck deck, GameBoard gameBoard, MessageHandler output)
        {
            Name = name;
            _hand = new List<Card>();
            _deck = deck;
            _gameBoard = gameBoard;
            Output = output; // Передаем делегат вывода сообщений
            Score = 0;
        }

        // Метод для присваиявания очков игроку
        public void AddPoints(int points)
        {
            Score += points;
            Output?.Invoke($"{Name} получает {points} очков. Теперь у него {Score} очков.");
        }


        // Метод для вытягивания карты из колоды
        public void DrawCard()
        {
            var card = _deck.DrawCard();
            if (card != null)
            {
                _hand.Add(card);
                card.Owner = this;
                Output?.Invoke($"{Name} вытянул карту: {card.Name}");
            }
            else
            {
                Output?.Invoke($"В колоде больше нет карт");
            }
        }

        // Метод для сброса карты из руки (карта перемещается на игровое поле)
        public void DiscardCard(Card card)
        {
            if (_hand.Contains(card))
            {
                _hand.Remove(card);
                _gameBoard.AddCardToDiscardPile(card);
                Output?.Invoke($"{Name} сбросил карту: {card.Name}");
            }
            else
            {
                throw new InvalidOperationException("Эта карта не находится в руке игрока.");
            }
        }

        // Метод для сброса карты по индексу (например, игрок выбирает карту для сброса)
        public void DiscardCard(int index)
        {
            if (index >= 0 && index < _hand.Count)
            {
                var card = _hand[index];
                DiscardCard(card);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Неверный индекс карты.");
            }
        }

        // Метод для использования карты из руки (с последующим сбросом на игровое поле)
        public Card PlayCard(int index)
        {
            if (index >= 0 && index < _hand.Count)
            {
                var card = _hand[index];
                Output?.Invoke($"{Name} разыграл карту: {card.Name}");
                _gameBoard.PlayCardOnBoard(card);
                _hand.Remove(card); // Карта перемещается на игровое поле, больше не в руке
                return card;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Неверный индекс карты.");
            }
        }

        // Метод для отображения карт в руке
        public void ShowHand()
        {
            Output?.Invoke($"Карты на руках у {Name}:");
            for (int i = 0; i < _hand.Count; i++)
            {
                Output?.Invoke($"{i + 1}. {_hand[i].Name} ({_hand[i].Type})");
            }
        }

        // Получение количества карт в руке
        public int HandCount => _hand.Count;

    }
}
