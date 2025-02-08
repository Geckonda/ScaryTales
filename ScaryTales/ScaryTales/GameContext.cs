using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameContext : IGameContext
    {
        public IGameState GameState { get; private set; }
        public IGameBoard GameBoard { get; private set; }
        public List<Player> Players { get; private set; }
        public Deck Deck { get; private set; }
        public ItemManager ItemManager { get; private set; }
        public GameManager GameManager { get; private set; }

        public GameContext(IGameState gameState,
            IGameBoard gameBoard,
            List<Player> players,
            Deck deck,
            ItemManager itemManager,
            GameManager gameManager)
        {
            GameState = gameState;
            GameBoard = gameBoard;
            Players = players;
            Deck = deck;
            ItemManager = itemManager;
            GameManager = gameManager;
        }
    }
}
