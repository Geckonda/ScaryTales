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
    public class OgreCard : Card
    {
        public override string Name => "Огр";

        public override CardType Type => CardType.Monster;

        public override int Points => 2;

        public override string EffectDescription => "Возьмите на руку 1 разыгранное место и 1 разыгранную женщину.";

        public override CardPosition PositionAfterPlay => CardPosition.BeforePlayer;

        public override int CardCountInDeck => 2;

        public override ICardEffect Effect => new OgreEffect();

        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new OgreCard();
        }
    }
}
