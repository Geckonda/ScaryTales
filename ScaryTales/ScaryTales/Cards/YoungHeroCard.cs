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
    public class YoungHeroCard : Card
    {
        public override string Name => "Молодой герой";

        public override CardType Type => CardType.Man;

        public override int Points => 2;

        public override string EffectDescription => "Возьмите из запаса 1 доспех или 1 меч.";

        public override CardPosition PositionAfterPlay => CardPosition.OnGameBoard;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect
            => new ItemDistributor(new List<ItemType> { ItemType.Armor, ItemType.Sword });

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new YoungHeroCard();
        }
    }
}
