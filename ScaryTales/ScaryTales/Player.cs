using ScaryTales.Abstractions;
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
        /// <summary>
        /// Выбирает карту из предоставленного списка
        /// </summary>
        private IPlayerInput _playerInput;
        /// <summary>
        /// Колода в руке игрока
        /// </summary>
        public List<Card> Hand => _hand;
        /// <summary>
        /// Количество карт в руке игрока
        /// </summary>
        public int HandCardCount => _hand.Count;
        /// <summary>
        /// Карты в руке игрока
        /// </summary>
        private List<Card> _hand;
        /// <summary>
        /// Предметы, которыми владеет игрок
        /// </summary>
        private List<Item> _itemsBag;
        /// <summary>
        /// Количество предметов в сумке игрока
        /// </summary>
        public int ItemsBagCount => _itemsBag.Count;

        public Player(string name, IPlayerInput playerInput)
        {
            Name = name;
            _hand = new List<Card>();
            _itemsBag = new List<Item>();
            Score = 0;
            _playerInput = playerInput;
        }

        /// <summary>
        /// Метод начисления очков игроку
        /// </summary>
        /// <param name="points">Очки для начисления</param>
        public void AddPoints(int points) => Score += points;
        /// <summary>
        /// Добавляет карты в руку
        /// </summary>
        /// <param name="card">Карта, которая окажется в руке</param>
        public void AddCardToHand(Card card) => _hand.Add(card);
        /// <summary>
        /// Есть ли карта в руке у игрока
        /// </summary>
        /// <returns>Если есть, вернет true, иначе false</returns>
        public bool HasCard(Card card) => _hand.Contains(card);
        /// <summary>
        /// Удаление карты из руки игрока
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCardFromHand(Card card) => _hand.Remove(card);

        /// <summary>
        /// Игрок выбирает карту со своей руки
        /// </summary>
        /// <returns>Карта на розыгрыш</returns>
        public Card SelectCardInHand()
            => _playerInput.SelectCard(_hand);
        /// <summary>
        /// Выбирает карту среди других карт
        /// </summary>
        /// <param name="cards">Карты, среди которых стоит выбрать</param>
        public Card SelectCardAmongOthers(List<Card> cards)
            => _playerInput.SelectCard(cards);
        /// <summary>
        /// Добавляет игроку предмет
        /// </summary>
        public void AddItemToItemBag(Item item) => _itemsBag.Add(item);
        /// <summary>
        /// Есть ли у игрока такой предмет
        /// </summary>
        public bool HasItem(Item item) => _itemsBag.Contains(item);
        /// <summary>
        /// Удаляет предмет у игрока
        /// </summary>
        public void RemoveItemFromItemBag(Item item) => _itemsBag.Remove(item);
        /// <summary>
        /// Игрок выбирает нужный ему предмет
        /// </summary>
        public Item SelectItem(List<Item> items)
            => _playerInput.SelectItem(items);
    }
}
