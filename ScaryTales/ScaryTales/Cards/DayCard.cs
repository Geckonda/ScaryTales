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
    public class DayCard : Card
    {
        public override string Name => "День";

        public override CardType Type => CardType.Event;

        public override int Points => 3;

        public override string EffectDescription => "Сейчас день. Сбросьте разыгранную карту 'Ночь'";

        public override CardPosition PositionAfterPlay => CardPosition.TimeOfDay;

        public override int CardCountInDeck => 3;

        public override ICardEffect Effect => new SwapToDayEffect();

        public override void ActivateEffect(IGameContext context)
        {
            var card = context.GameBoard.GetCardFormTimeOfDaySlot()!;
            context.GameManager.PutCardToDiscardPile(card);
            if (context.GameState.IsNight == true)
                Effect.ApplyEffect(context);
        }

        public override Card Clone()
        {
            return new DayCard();
        }
    }
}
