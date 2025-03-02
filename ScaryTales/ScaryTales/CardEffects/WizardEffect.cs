using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class WizardEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public Task ApplyEffect(IGameContext context)
        {
            var manager = context.GameManager;
            var player = context.GameState.GetCurrentPlayer();

            var card = manager.TryDrawCardFromDeck();
            if(card != null)
            {
                manager.PrintMessage($"Игрок {player.Name} вытянул карту {card.Name} и тут же разыграл.");
                manager.PutCardInPlayerHand(card, player);
                manager.PlayCard(card);
                //manager.AddPointsToPlayer(player, card.Points);
                //manager.ActivateInstantCardEffect(card);
                //manager.MoveCardToItsPosition(card);
            }
            return Task.CompletedTask;
        }
    }
}
