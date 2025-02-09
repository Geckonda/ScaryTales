using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class Deck
    {
        /// <summary>
        /// Основная колода
        /// </summary>
        private List<Card> _cards = new();

        /// <summary>
        /// Конструктор для создания колоды по шаблонам
        /// </summary>
        /// <param name="templates">Шаблоны</param>
        public Deck(List<Card> templates)
        {
            foreach (var template in templates)
                for (int i = 0; i < template.CardCountInDeck; i++)
                    _cards.Add(template.Clone());

            Shuffle();
        }

        /// <summary>
        /// Метод для тасовки колоды
        /// </summary>
        public void Shuffle()
        {
            var rnd = new Random();
            _cards = _cards.OrderBy(x => rnd.Next()).ToList();
        }

        /// <summary>
        /// Метод для вытягивания карты из колоды
        /// </summary>
        /// <returns>Карта на вершине колоды</returns>
        public Card? DrawCard()
        {
            if (_cards.Count == 0) return null;

            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }


        /// <summary>
        /// Получение текущего состояния колоды (количество карт)
        /// </summary>
        public int CardsRemaining => _cards.Count;

        /// <summary>
        /// Получение конкретной карты по имени из колоды
        /// </summary>
        /// <param name="name">Название карты</param>
        /// <returns>Если такой карты нет, вернет null</returns>
        public Card? TakeCardByName(string name)
        {
            if (_cards.Count == 0) return null;

            var card = _cards.FirstOrDefault(x => x.Name == name);
            if (card != null)
                _cards.Remove(card);
            return card;
        }
    }
}
