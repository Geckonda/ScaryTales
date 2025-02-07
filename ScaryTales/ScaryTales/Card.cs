using Microsoft.VisualBasic;
using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScaryTales
{
    public enum CardType
    {
        Woman, Man, Event, Monster, Place
    }
    public enum CardPosition
    {
        InDeck,       // В колоде (не разыгранная)
        InHand,       // В руке игрока
        BeforePlayer, // На игровом поле перед игроком
        OnGameBoard, // На игровом поле общем
        Discarded      // Битая карта
    }
    public enum CardEffectType
    {
        PassiveFarmAtTheEnd,
        Instant
    }
    public enum CardEffectTimeApply
    {
        Immediately,
        AtTheEnd,
        PassiveIncome

    }
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
        public abstract CardPosition PositionAfterDiscard { get; }
        public Player? Owner { get; set; }
        /// <summary>
        /// Максимальное количество такой карты в калоде
        /// </summary>
        public abstract int CardCountInDeck { get; }

        public abstract ICardEffect Effect { get; }

        //protected abstract void AddEffect(ICardEffect effect);

        public abstract void ActivateEffect(IGameBoard gameBoard,
            IGameState gameState, CardEffectTimeApply time);

        public abstract Card Clone();
    }
}
