using ScaryTales.Abstractions;
using ScaryTales.CardEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Cards
{
    public class EnchantedForestCard : Card
    {
        public override string Name => "Зачарованный лес";

        public override CardType Type => CardType.Place;

        public override int Points => 2;

        public override string EffectDescription => "Возьмите 1 карту из колоды. Если сейчас день, все игроки берут по 1 карте из колоды. Если сейчас ночь, все игроки сбрасывают по 1 карте с руки.";

        public override CardPosition PositionAfterPlay => CardPosition.OnGameBoard;

        public override int CardCountInDeck => 6;

        public override ICardEffect Effect => new EnchantedForestEffect();

        public override void ActivateEffect(IGameBoard gameBoard, IGameState gameState, CardEffectTimeApply time)
        {
            if (Effect.EffectTime == time)
            {
                Effect.ApplyEffect(gameState, gameBoard);
            }
        }

        public override Card Clone()
        {
            return new EnchantedForestCard();
        }
    }
}
