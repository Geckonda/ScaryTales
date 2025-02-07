using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class WizardEffect : ICardEffect
    {
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.Immediately;

        public CardEffectType Type => CardEffectType.Instant;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {
            var x = gameState.GetDeck();
            if (gameState.GetDeck().CardsRemaining == 0)
            {
                gameState.Notificate("В колоде не осталось карт.");
                return;
            }
            var player = gameState.GetCurrentPlayer();
            player.DrawCard();
            var card = player.PlayCard(player.HandCount - 1);
            card.ActivateEffect(gameBoard, gameState, card.Effect.EffectTime);
        }
    }
}
