using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Helpers
{
    public static class Printer
    {
        /// <summary>
        /// Выводит список предоставленных карт
        /// </summary>
        public static void PrintCardList(List<Card> cards,
            Action<string> notificate)
        {
            notificate($"Карты:");
            for (int i = 0; i < cards.Count; i++)
            {
                notificate($"{i + 1} - {cards[i].Name}");
            }
        }
        /// <summary>
        /// Выводит список карт вместе с переданным типом. Ничего не фильтрует!
        /// </summary>
        /// <param name="notificate">Метод для вывода</param>
        public static void PrintCardList(List<Card> cards,
            Action<string> notificate,
            string cardType)
        {
            notificate($"Карты типа {cardType}");
            for (int i = 0; i < cards.Count; i++)
            {
                notificate($"{i + 1} - {cards[i].Name}");
            }
        }
        /// <summary>
        /// Выводит список предоставленных предметов
        /// </summary>
        public static void PrintItemList(List<Item> items,
            Action<string> notificate)
        {
            notificate("Предметы:");
            for (int i = 0; i < items.Count; i++)
            {
                notificate($"{i + 1} - {items[i].Name}");
            }
        }
        /// <summary>
        /// Выводит список предметов вместе с переданным типом. Ничего не фильтрует! 
        /// </summary>
        /// <param name="notificate">Метод для вывода</param>
        public static void PrintItemList(List<Item> items,
            Action<string> notificate,
            string itemType)
        {
            notificate($"Предмет типа {itemType}");
            for (int i = 0; i < items.Count; i++)
            {
                notificate($"{i + 1} - {items[i].Name}");
            }
        }
    }
}
