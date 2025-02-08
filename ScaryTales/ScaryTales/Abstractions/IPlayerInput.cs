using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    /// <summary>
    /// Отвечает за выбор объектов
    /// </summary>
    public interface IPlayerInput
    {
        /// <summary>
        /// Позволяет игроку выбрать одну карту из списка.
        /// </summary>
        Card SelectCard(List<Card> cards);

        /// <summary>
        /// Позволяет игроку выбрать один предмет из списка.
        /// </summary>
        Item SelectItem(List<Item> items);
        /// <summary>
        /// Позволяет пользователю выбрать Да/Нет
        /// </summary>
        bool YesOrNo();
    }
}
