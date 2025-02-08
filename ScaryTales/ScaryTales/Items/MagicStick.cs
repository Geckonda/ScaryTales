using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Items
{
    public class MagicStick : Item
    {
        public override string Name => "Волшебная палочка";

        public override ItemType Type => ItemType.MagicStick;

        public override int DefaultAmount => 4;

        public override Item Clone()
        {
            return new MagicStick();
        }
    }
}
