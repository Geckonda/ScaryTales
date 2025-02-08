using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Enums
{
    /// <summary>
    /// Позиция карты
    /// </summary>
    public enum CardPosition
    {
        /// <summary>
        /// В колоде (не разыгранная)
        /// </summary>
        InDeck,
        /// <summary>
        /// В руке игрока
        /// </summary>
        InHand,
        /// <summary>
        /// На игровом поле перед игроком
        /// </summary>
        BeforePlayer,
        /// <summary>
        /// На игровом поле общем
        /// </summary>
        OnGameBoard,
        /// <summary>
        /// Сброшенная карта
        /// </summary>
        Discarded
    }
}
