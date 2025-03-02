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
        public Task<Card> SelectCard(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        public Task<Item> SelectItem(List<Item> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> YesOrNo()
        {
            throw new NotImplementedException();
        }
    }
}
