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
    public class FollyKingCard : Card
    {
        public override string Name => "Сумасбродство короля";

        public override CardType Type => CardType.Event;

        public override int Points => 0;

        public override string EffectDescription => "Возьмите 1 карту из колоды. Если сейчас день, получите 1 ПО за каждое разыгранное место. Если сейчас ночь, получите 2 ПО за каждое разыгранное место.";

        public override CardPosition PositionAfterPlay => CardPosition.Discarded;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect => new FollyKingEffect();

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new FollyKingCard();
        }
    }
}
