using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class ItemManager
    {
        /// <summary>
        /// Доступные игрокам предметы
        /// </summary>
        private List<Item> _availableItems = new();
        /// <summary>
        /// Использованные предметы
        /// </summary>
        private List<Item> _usedItems = new();

        /// <summary>
        /// Конструктор для создания мешочка с предметами по шаблонам
        /// </summary>
        /// <param name="templates">Шаблоны</param>
        public ItemManager(List<Item> templates)
        {
            foreach (var template in templates)
                for (int i = 0; i < template.DefaultAmount; i++)
                    _availableItems.Add(template.Clone());
        }
        /// <summary>
        /// Возвращает предмет по его типу.
        /// </summary>
        /// <param name="type">Тип предмета</param>
        /// <returns>Если такой предмет еще есть, вернет его. Иначе null.</returns>
        public Item? GetItemByType(ItemType type)
        {
            var item = _availableItems.FirstOrDefault(x => x.Type == type);
            if(item != null)
                _availableItems.Remove(item);
            return item;
        }

        public Item? GetCloneItemByType(ItemType type)
        {
            var item = _availableItems.FirstOrDefault(x => x.Type == type);
                return item?.Clone();
        }
        /// <summary>
        /// Получение количества предмета конкретного типа
        /// </summary>
        public int CountItemByType(ItemType type)
            => _availableItems.Where(x => x.Type == type)
                .ToList().Count;
        /// <summary>
        /// Помещение предмета в список использованных
        /// </summary>
        /// <param name="item"></param>
        public void PutItemToUsed(Item item) => _usedItems.Add(item);
    }
}
