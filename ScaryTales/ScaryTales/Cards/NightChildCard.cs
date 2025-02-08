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
    public class NightChildCard : Card
    {
        public override string Name => "Дитя ночи";

        public override CardType Type => CardType.Monster;

        public override int Points => 0;

        public override string EffectDescription => "Если сейчась ночь, получите 2 ПО в конце своего хода.";

        public override CardPosition PositionAfterPlay => CardPosition.BeforePlayer;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect { get; } = new PassiveFixPointsFarmEffect(2);

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new NightChildCard();
        }
    }
}
