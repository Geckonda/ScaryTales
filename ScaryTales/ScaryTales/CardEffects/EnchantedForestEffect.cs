using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class EnchantedForestEffect : ICardEffect
    {
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.Immediately;

        public CardEffectType Type => CardEffectType.Instant;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {
            var player = gameState.GetCurrentPlayer();
            player.DrawCard();

            var players = gameState.GetPlayers();
            if (!gameState.IsNight)
            {
                foreach(var p in players)
                {
                    p.DrawCard();
                }
            }
            else
            {
                // Временно рандомный сброс. Должен быть выбор игрока.
                foreach (var p in players)
                {
                    Random rnd = new();
                    p.DiscardCardFormHand(rnd.Next(p.HandCount));
                }
            }
        }
    }
}
