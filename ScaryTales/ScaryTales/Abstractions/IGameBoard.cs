using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    public interface IGameBoard
    {
        /// <summary>
        /// Получение всех разыгранных карт, которые в данный момент на столе
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetCardsOnBoard();
        /// <summary>
        /// Метод для сброса карты (перемещение из игры на столе в колоду сброса)
        /// </summary>
        /// <param name="card">Какую карту нужно сбросить</param>
        public void AddCardToDiscardPile(Card card);
    }
}
