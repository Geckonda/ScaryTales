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
    public class FairyCard : Card
    {
        public override string Name => "Фея";

        public override CardType Type => CardType.Woman;

        public override int Points => 2;

        public override string EffectDescription => "Возьмите из запаса 1 волшебную палочку или 1 меч";

        public override CardPosition PositionAfterPlay => CardPosition.OnGameBoard;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect =>
            new ItemDistributor(new List<ItemType> { ItemType.MagicStick, ItemType.Sword });

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new FairyCard();
        }
    }
}
