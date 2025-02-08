using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Items
{
    public class Armor : Item
    {
        public override string Name => "Доспех";

        public override ItemType Type => ItemType.Armor;

        public override int DefaultAmount => 4;

        public override Item Clone()
        {
            return new Armor();
        }
    }
}
