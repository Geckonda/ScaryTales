using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    /// <summary>
    /// Отвечает за состояние игры
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Проверяет, ночь ли в игре.
        /// </summary>
        bool IsNight { get; }

        /// <summary>
        /// Проверяет, завершена ли игра.
        /// </summary>
        bool IsGameOver { get; }

        /// <summary>
        /// Счетчик текущих ходов.
        /// </summary>
        int TurnCount { get; }

        /// <summary>
        /// Получить текущего игрока.
        /// </summary>
        Player GetCurrentPlayer();

        /// <summary>
        /// Получить список всех игроков в игре.
        /// </summary>
        List<Player> GetPlayers();

        /// <summary>
        /// Перейти к следующему ходу.
        /// </summary>
        void NextTurn();

        /// <summary>
        /// Завершить игру.
        /// </summary>
        void EndGame();

        /// <summary>
        /// Переключить фазу игры.
        /// </summary>
        void ToggleNightPhase();
    }

}
