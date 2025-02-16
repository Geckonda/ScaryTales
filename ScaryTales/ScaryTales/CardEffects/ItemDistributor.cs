using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class ItemDistributor : ICardEffect
    {
        private readonly List<ItemType> _itemTypes;
        public CardEffectTimeType Type => CardEffectTimeType.Instant;
        public ItemDistributor(List<ItemType> types)
        {
            _itemTypes = types;
        }

        public void ApplyEffect(IGameContext context)
        {
            var manager = context.GameManager;
            var itemManager = context.ItemManager;
            var player = context.GameState.GetCurrentPlayer();

            // Собираем доступные предметы из списка типов
            var availableItems = _itemTypes
                .Select(itemManager.GetCloneItemByType)
                .Where(item => item != null)
                .ToList();

            if (availableItems.Count == 0)
            {
                manager.PrintMessage("Нет доступных предметов в запасе.");
                return;
            }

            var inavailableItems = _itemTypes
                .Where(type => !availableItems.Any(item => item.Type == type))
                .ToList();
            if (inavailableItems.Count > 0)
                PrintInavailableItems(inavailableItems!, manager.PrintMessage);

            // Игрок выбирает предмет из доступных
            var selectedItem = player.SelectItem(availableItems!);

            // Получаем оригинальный предмет (не клон) и добавляем в инвентарь
            var originalItem = itemManager.GetItemByType(selectedItem.Type);
            if (originalItem != null)
            {
                manager.PutItemInPlayerItemBag(originalItem, player);
            }
        }
        private void PrintInavailableItems(List<ItemType> items, Action<string> print)
        {
            foreach (var item in items)
            {
                switch (item)
                {
                    case ItemType.Coin:
                        print("В запасе не осталось золотых монет.");
                        break;
                    case ItemType.Sword:
                        print("В запасе не осталось мечей.");
                        break;
                    case ItemType.Armor:
                        print("В запасе не осталось доспехов.");
                        break;
                    case ItemType.MagicStick:
                        print("В запасе не осталось волшебных палок.");
                        break;
                }
            }
        }
    }
}
