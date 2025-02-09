using ScaryTales.Abstractions;
using ScaryTales.CardEffects;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Cards
{
    public class CharmCard : Card
    {
        public override string Name => "Чары";

        public override CardType Type => CardType.Event;

        public override int Points => 1;

        public override string EffectDescription => "Возьмите из запаса 1 предмет: доспех, волшебную палку, золотую монету или меч.";

        public override CardPosition PositionAfterPlay => CardPosition.Discarded;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect
            => new ItemDistributor(new List<ItemType> 
            { ItemType.Armor, ItemType.MagicStick, ItemType.Coin, ItemType.Sword });

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new CharmCard();
        }
    }
}
