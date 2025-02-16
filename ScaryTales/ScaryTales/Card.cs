using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public abstract class Card
    {
        public abstract string Name { get; }
        public abstract CardType Type { get; }
        public abstract int Points { get; }
        public abstract string EffectDescription { get; }
        /// <summary>
        /// Позиция карты в реальном времени
        /// </summary>
        public CardPosition Position { get; set; } = CardPosition.InDeck;

        /// <summary>
        /// Позиция карты после разыгрывания
        /// </summary>
        public abstract CardPosition PositionAfterPlay { get; }
        /// <summary>
        /// Текущий владелец карты
        /// </summary>
        public Player? Owner { get; set; }
        /// <summary>
        /// Сколько такой карты в колоде
        /// </summary>
        public abstract int CardCountInDeck { get; }

        public abstract ICardEffect Effect { get; }


        public abstract void ActivateEffect(IGameContext context);

        public abstract Card Clone();
    }
}
