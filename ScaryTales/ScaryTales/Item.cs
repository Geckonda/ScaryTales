using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public abstract class Item
    {
        public abstract string Name { get; }
        public abstract ItemType Type { get; }
        /// <summary>
        /// Количество предметов по умолчанию
        /// </summary>
        public abstract int DefaultAmount{ get; }
        public abstract Item Clone();
    }
}
