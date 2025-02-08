using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    public interface IGameContext
    {
        public IGameState GameState { get; }
        public IGameBoard GameBoard { get; }
        public List<Player> Players { get; }
        public Deck Deck { get; }
        public ItemManager ItemManager { get; }
        public GameManager GameManager { get; }
    }
}
