using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Interaction_Entities.EnvUnity
{
    public class UnityPlayerInput : IPlayerInput
    {
        public Card SelectCard(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        public Item SelectItem(List<Item> items)
        {
            throw new NotImplementedException();
        }

        public bool YesOrNo()
        {
            throw new NotImplementedException();
        }
    }
}
