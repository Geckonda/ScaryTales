using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Items
{
    public class Coin : Item
    {
        public override string Name => "Золотая монета";

        public override ItemType Type => ItemType.Coin;

        public override int DefaultAmount => 8;

        public override Item Clone()
        {
            return new Coin();
        }
    }
}
