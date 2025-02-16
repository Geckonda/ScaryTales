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
    public class PrincessCard : Card
    {
        public override string Name => "Принцесса";

        public override CardType Type => CardType.Woman;

        public override int Points => 2;

        public override string EffectDescription => "Возьмите на руку 1 разыгранного мужчину.";

        public override CardPosition PositionAfterPlay => CardPosition.OnGameBoard;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect => new PrincessEffect();

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new PrincessCard();
        }
    }
}
