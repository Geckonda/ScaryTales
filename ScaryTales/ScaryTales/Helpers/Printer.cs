using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Helpers
{
    public static class Printer
    {
        public static void PrintCardList(List<Card> cards,
            Action<string> notificate,
            string cardType)
        {
            var card = cards.FirstOrDefault();
            notificate($"Карты типа {cardType}");
            for (int i = 0; i < cards.Count; i++)
            {
                notificate($"{i + 1} - {cards[i].Name}");
            }
        }
    }
}
