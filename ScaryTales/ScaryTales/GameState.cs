using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameState : IGameState
    {
        public bool IsNight { get; private set; } 
        public bool IsGameOver { get; private set; } 
        public int TurnCount { get; private set; } 
        public int CurrentPlayerIndex { get; private set; } 
        public List<Player> Players { get; private set; }
        public GameState(List<Player> players)
        {
            Players = players;
            CurrentPlayerIndex = 0; // Начинаем с первого игрока
            IsNight = true;
            IsGameOver = false;
            TurnCount = 0;
        }

        public void EndGame()
        {
            IsGameOver = true;
        }

        public Player GetCurrentPlayer() => Players[CurrentPlayerIndex];

        public List<Player> GetPlayers() => Players;

        public void NextTurn()
        {
            TurnCount++;
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
        }

        public void ToggleNightPhase()
        {
            IsNight = !IsNight;
        }
    }
}
