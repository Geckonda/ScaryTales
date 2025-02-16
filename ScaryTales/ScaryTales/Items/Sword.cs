using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Items
{
    public class Sword : Item
    {
        public override string Name => "Меч";

        public override ItemType Type => ItemType.Sword;

        public override int DefaultAmount => 4;

        public override Item Clone()
        {
            return new Sword();
        }
    }
}
