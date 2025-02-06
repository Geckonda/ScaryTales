using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    public interface IGameState
    {
        /// <summary>
        /// Проверяет, ночь ли в игре.
        /// </summary>
        bool IsNight { get; set; }

        /// <summary>
        /// Получение списка игроков в игре.
        /// </summary>
        List<Player> GetPlayers();

        /// <summary>
        /// Получение текущего игрока.
        /// </summary>
        Player GetCurrentPlayer();

        /// <summary>
        /// Доступ к колоде.
        /// </summary>
        Deck GetDeck();
    }
}
