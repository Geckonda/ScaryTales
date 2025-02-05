using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Cards
{
    public class DarkLord : Card
    {
        public override string Name => "Темный владыка";

        public override CardType Type => CardType.Monster;

        public override int Points => 0;

        public override string EffectDescription => "Получите 2 ПО за каждого разыгранного злодея. Сбросьте 1 разыгранное место.";

        public override CardPosition PositionAfterDiscard => CardPosition.Discarded;

        public override int CardCountInDeck => 2;

        public override CardEffectTimeApply EffectTimeApply => CardEffectTimeApply.Immediately;

        public override void ActivateEffect(IEnvironment env)
        {
            if (this.Owner == null)
                throw new InvalidOperationException("Карта никому не принадлежит");

            var cards = env.GetCardsOnBoard();
            foreach (var card in cards)
            {
                if (card.Type == CardType.Monster)
                    this.Owner.AddPoints(2);
            }
        }
    }
}
