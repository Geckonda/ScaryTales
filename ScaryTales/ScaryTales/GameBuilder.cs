using ScaryTales.Cards;
using ScaryTales.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameBuilder
    {
        private readonly MessageHandler _messageHandler;
        public GameBuilder(MessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }
        public GameManager Build()
        {
            var deck = new Deck(MakeTemplates());
            var gameBoard = new GameBoard(_messageHandler);

            deck.ShowDeckInfo();
            // Создаем игроков
            var player1 = new Player("Игрок 1", deck, gameBoard, _messageHandler);
            var player2 = new Player("Игрок 2", deck, gameBoard, _messageHandler);

            // Список игроков
            var players = new List<Player> { player1, player2 };

            // Создаем игровой менеджер
            return new GameManager(players, deck, gameBoard, _messageHandler);
        }
        private List<Card> MakeTemplates()
        {
            var templates = new List<Card>();
            templates.Add(new NightChild());
            templates.Add(new OldMaster());
            templates.Add(new DarkLord());

            return templates;
        }
    }
}
