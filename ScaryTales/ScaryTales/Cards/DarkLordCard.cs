﻿using ScaryTales.Abstractions;
using ScaryTales.CardEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Cards
{
    public class DarkLordCard : Card
    {
        public override string Name => "Темный владыка";

        public override CardType Type => CardType.Monster;

        public override int Points => 0;

        public override string EffectDescription => "Получите 2 ПО за каждого разыгранного злодея. Сбросьте 1 разыгранное место.";

        public override CardPosition PositionAfterDiscard => CardPosition.Discarded;

        public override int CardCountInDeck => 8;

        public override ICardEffect Effect => new DarkLordEffect();

        public override void ActivateEffect(IGameBoard gameBoard, IGameState gameState, CardEffectTimeApply time)
        {
            if (Effect.EffectTime == time)
            {
                Effect.ApplyEffect(gameState, gameBoard);
            }
        }

        public override Card Clone()
        {
            return new DarkLordCard();
        }
    }
}
