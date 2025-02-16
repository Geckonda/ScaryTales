using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    public interface ICardEffect
    {
        public CardEffectTimeType Type { get; } // Тип эффекта
        public void ApplyEffect(IGameContext context);
    }
}
