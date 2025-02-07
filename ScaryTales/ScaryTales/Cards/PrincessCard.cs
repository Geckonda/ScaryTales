using ScaryTales.Abstractions;
using ScaryTales.CardEffects;
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

        public override int CardCountInDeck => 8;

        public override ICardEffect Effect => new PrincessEffect();

        public override void ActivateEffect(IGameBoard gameBoard,
            IGameState gameState, CardEffectTimeApply time)
        {
            if (Effect.EffectTime == time)
            {
                Effect.ApplyEffect(gameState, gameBoard);
            }
        }

        public override Card Clone()
        {
            return new PrincessCard();
        }
    }
}
