using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    public interface ICardEffect
    {
        public CardEffectTimeApply EffectTime { get; } // Время активации эффекта // Нужен ли?
        public CardEffectType Type { get; } // Тип эффекта
        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard);
    }
}
