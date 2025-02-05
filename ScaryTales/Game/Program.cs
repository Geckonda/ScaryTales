using ScaryTales;
using System.Numerics;
using System.Text.Json;
using System.Threading.Channels;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new GameBuilder((message) => Console.WriteLine(message));
            var gameManager = builder.Build();

            // Начало игры
            gameManager.StartGame();
        }
    }
}
