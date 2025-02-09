using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class FairyEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public void ApplyEffect(IGameContext context)
        {
            var state = context.GameState;
            var player = state.GetCurrentPlayer();
            var itemManager = context.ItemManager;
            var manager = context.GameManager;

            // Получаем предметы
            var items = new List<Item?>
            {
                itemManager.GetCloneItemByType(ItemType.MagicStick),
                itemManager.GetCloneItemByType(ItemType.Sword)
            }.Where(item => item != null).ToList(); // Фильтруем ненулевые

            // Если нет доступных предметов
            if (!items.Any())
            {
                manager.PrintMessage("В запасе нет волшебной палочки и меча.");
                return;
            }

            // Выводим сообщение о недостающих предметах
            var missingItems = new List<string>();
            if (!items.Any(i => i!.Type == ItemType.MagicStick)) missingItems.Add("волшебной палочки");
            if (!items.Any(i => i!.Type == ItemType.Sword)) missingItems.Add("меча");

            if (missingItems.Any())
                manager.PrintMessage($"В запасе нет {string.Join(" и ", missingItems)}.");

            // Игрок выбирает предмет
            var selectedItem = player.SelectItem(items!);

            // Добавляем предмет в инвентарь игрока
            manager.PutItemInPlayerItemBag(itemManager.GetItemByType(selectedItem.Type)!, player);
        }

    }
}
