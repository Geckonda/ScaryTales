using ScaryTales.Abstractions;
using ScaryTales.CardEffects;
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

        public override CardPosition PositionAfterDiscard => CardPosition.BeforePlayer;

        public override int CardCountInDeck => 12;

        protected override ICardEffect Effect { get; } = new PassiveIncomeEffect();
    }
}
