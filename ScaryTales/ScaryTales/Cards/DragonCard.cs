using ScaryTales.Abstractions;
using ScaryTales.CardEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Cards
{
    public class DragonCard : Card
    {
        public override string Name => "Дракон";

        public override CardType Type => CardType.Monster;

        public override int Points => 0;

        public override string EffectDescription => "Сбросьте 1 разыгранное место и 1 разыгранного мужчину. Получите 2 ПО за каждую сброшенную карту.";

        public override CardPosition PositionAfterPlay => CardPosition.Discarded;

        public override int CardCountInDeck => 8;

        public override ICardEffect Effect => new DragonEffect();

        public override void ActivateEffect(IGameBoard gameBoard, IGameState gameState, CardEffectTimeApply time)
        {
            if (Effect.EffectTime == time)
            {
                Effect.ApplyEffect(gameState, gameBoard);
            }
        }

        public override Card Clone()
        {
            return new DragonCard();
        }
    }
}
