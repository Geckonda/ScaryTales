using ScaryTales.Abstractions;
using ScaryTales.Cards;
using ScaryTales.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameBuilder
    {
        private readonly IPlayerInput _playerInput;
        private readonly INotifier _notifier;

        public GameBuilder(IPlayerInput playerInput, INotifier notifier)
        {
            _playerInput = playerInput;
            _notifier = notifier;
        }
        public GameManager Build()
        {
            var deck = new Deck(MakeCardTemplates());
            var items = new ItemManager(MakeItemTemplates());
            // Создаем игроков
            var player1 = new Player("Саша", _playerInput);
            var player2 = new Player("Вова", _playerInput);

            // Список игроков
            var players = new List<Player> { player1, player2 };

            // Создаем игровой менеджер
            return new GameManager(players, deck, items, _notifier);
        }
        private List<Card> MakeCardTemplates()
        {
            return new List<Card>()
            {
                new NightChildCard(),
                new OldMasterCard(),
                new DarkLordCard(),
                new DragonCard(),
                new EnchantedForestCard(),
                new PrincessCard(),
                new MerchantCard(),
                new WizardCard(),
                new NightCard(),
                new DayCard(),
            };
        }
        private List<Item> MakeItemTemplates()
        {
            return new List<Item>()
            {
                new Coin(),
                new Armor(),
                new Sword(),
                new MagicStick()
            };
        }
    }
}
