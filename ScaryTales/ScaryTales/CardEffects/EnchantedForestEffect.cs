using ScaryTales.Abstractions;
using ScaryTales.Enums;
using ScaryTales.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class EnchantedForestEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public void ApplyEffect(IGameContext context)
        {
            var state = context.GameState;
            var manager = context.GameManager;
            var player = state.GetCurrentPlayer();
            var players = state.GetPlayers();
            var deck = context.Deck;

            if(deck.CardsRemaining == 0)
            {
                manager.PrintMessage("В колоде не осталось карт.");
                return;
            }
            manager.DrawCard(player);

            if (deck.CardsRemaining == 0)
            {
                manager.PrintMessage("В колоде не осталось карт.");
                return;
            }

            if (!state.IsNight)
            {
                manager.PrintMessage("Все игроки вытягивают 1 карту из колоды");
                foreach (var p in players)
                {
                    manager.DrawCard(p);
                }
            }
            else
            {
                manager.PrintMessage("Все игроки сбрасывают 1 карту из своей руки");
                foreach (var p in players)
                {
                    var card = p.SelectCardAmongOthers(p.Hand);
                    p.RemoveCardFromHand(card);
                    manager.PutCardToDiscardPile(card);
                }
            }
        }
    }
}
