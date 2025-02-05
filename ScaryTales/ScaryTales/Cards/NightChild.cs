using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Cards
{
    public class NightChild : Card
    {
        public override string Name => "Дитя ночи";

        public override CardType Type => CardType.Monster;

        public override int Points => 0;

        public override string EffectDescription => "Если сейчась ночь, получите 2 ПО в конце своего хода.";

        public override CardPosition PositionAfterDiscard => CardPosition.BeforePlayer;

        public override int CardCountInDeck => 12;

        public override CardEffectTimeApply EffectTimeApply => CardEffectTimeApply.AtTheEnd;

        /// <summary>
        /// Если сейчась ночь, получите 2 ПО в конце своего хода
        /// </summary>
        /// <param name="env">Игровое поле</param>
        /// <exception cref="InvalidOperationException">Отсутсиве владельца у карты</exception>
        public override void ActivateEffect(IEnvironment env)
        {
            if (this.Owner == null)
                throw new InvalidOperationException("Карта никому не принадлежит");
            if(env.IsNight)
                this.Owner.AddPoints(2);
        }
    }
}
