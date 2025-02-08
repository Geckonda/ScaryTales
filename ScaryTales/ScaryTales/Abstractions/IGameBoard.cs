using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    /// <summary>
    /// Управление картами на игровом поле
    /// </summary>
    public interface IGameBoard
    {
        /// <summary>
        /// Получение всех разыгранных карт, которые в данный момент на столе
        /// </summary>
        /// <returns>Все разыгранные карты на столе</returns>
        public List<Card> GetCardsOnBoard();
        /// <summary>
        /// Получение всех разыгранных карт конкретного игрока, которые в данный момент на столе
        /// </summary>
        public List<Card> GetCardsOnBoard(Player player);
        /// <summary>
        /// Получение всех уже сброшенных карт
        /// </summary>
        /// <returns>Все сброшенные карты за игру</returns>
        public List<Card> GetCardsFromDiscardPile();
        /// <summary>
        /// Получение разыгранных карт по типу, которые в данный момент на столе
        /// </summary>
        /// <param name="type">Тип карты</param>
        /// <returns>Список карт конкретного типа</returns>
        public List<Card> GetCardsOnBoard(CardType type);
        /// <summary>
        /// Получение разыгранных карт по названию, которые в данный момент на столе
        /// </summary>
        /// <param name="name">Название карты</param>
        public List<Card> GetCardsOnBoard(string name);
        /// <summary>
        /// Метод для сброса карты (перемещение со стола в колоду сброса)
        /// </summary>
        /// <param name="card">Картя для сброса</param>
        public void MoveCardFromBoardToDiscardPile(Card card);
        /// <summary>
        /// Разыгрывает карту на стол
        /// </summary>
        /// <param name="card"></param>
        public void AddCardOnBoard(Card card);
        /// <summary>
        /// Метод для перемещения всех карт с игрового стола в колоду сброса
        /// </summary>
        public void MoveAllCardsToDiscardPile();
        /// <summary>
        /// Удаляет карту с игрвого поля
        /// </summary>
        /// <param name="card">Картя на удаление</param>
        public void RemoveCardFromBoard(Card card);
        /// <summary>
        /// Получение количества карт на столе
        /// </summary>
        /// <returns></returns>
        public int CardsOnBoardCount();
        /// <summary>
        /// Получение количества карт в колоде сброса
        /// </summary>
        /// <returns></returns>
        public int DiscardPileCount();
        /// <summary>
        /// Добавляет карту в колоду сброса
        /// </summary>
        public void AddCardToDiscardPile(Card card);
        /// <summary>
        /// Устанавливает карту времени суток на столе
        /// </summary>
        public void SetTimeOfDaySlot(Card card);
        /// <summary>
        /// Возвращает карту, которая находится в слоте времени суток
        /// </summary>
        /// <returns></returns>
        public Card? GetCardFormTimeOfDaySlot();
    }
}
