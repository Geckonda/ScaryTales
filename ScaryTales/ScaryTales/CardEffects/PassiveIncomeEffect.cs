using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class PassiveIncomeEffect : ICardEffect
    {
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.PassiveIncome;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {

        }
    }
}
