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
    public class MerchantCard : Card
    {
        public override string Name => "Купец";

        public override CardType Type => CardType.Man;

        public override int Points => 0;

        public override string EffectDescription => "Возьмите 2 карты из колоды. Получите 2 ПО за каждого разыгранного купца.";

        public override CardPosition PositionAfterPlay => CardPosition.OnGameBoard;

        public override int CardCountInDeck => 3;

        public override ICardEffect Effect => new MerchantEffect();
        
        public override void ActivateEffect(IGameContext context)
        {
            Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new MerchantCard();
        }
    }
}
