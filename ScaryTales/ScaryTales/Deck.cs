using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class Deck
    {

        private List<Card> _cards = new();           // Основная колода

        // Конструктор для создания колоды из списка карт
        public Deck(List<Card> templates)
        {
            foreach (var template in templates)
                for (int i = 0; i < template.CardCountInDeck; i++)
                    _cards.Add(template);

            Shuffle();                       // Тасуем основную колоду при создании
        }

        // Метод для тасовки колоды
        public void Shuffle()
        {
            var rnd = new Random();
            _cards = _cards.OrderBy(x => rnd.Next()).ToList();
        }

        // Метод для вытягивания карты из колоды
        public Card? DrawCard()
        {
            //if (_cards.Count == 0) throw new InvalidOperationException("Колода пуста!");
            if (_cards.Count == 0) return null;

            var card = _cards[0];
            _cards.RemoveAt(0);
            card.Position = CardPosition.InHand; // Меняем позицию карты на "в руке"
            return card;
        }


        // Получение текущего состояния колоды (количество карт)
        public int CardsRemaining => _cards.Count;


        // Вывод информации о всех картах в основной колоде
        public void ShowDeckInfo()
        {
            Console.WriteLine($"В колоде {_cards.Count} карт:");
            foreach (var card in _cards)
            {
                Console.WriteLine($"{card.Name} ({card.Type}) - {card.Position}");
            }
        }
    }
}
