using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class FollyKingEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public void ApplyEffect(IGameContext context)
        {
            var state = context.GameState;
            var board = context.GameBoard;
            var manager = context.GameManager;
            var player = state.GetCurrentPlayer();

            manager.DrawCard(player);
            var places = board.GetCardsOnBoard(CardType.Place);
            if (places.Count == 0)
            {
                manager.PrintMessage("Нет ни одной карты типа 'Место' на столе");
                return;
            }
            var earnedPoints = places.Count;
            if (state.IsNight)
                manager.AddPointsToPlayer(player, earnedPoints * 2);
            else
                manager.AddPointsToPlayer(player, earnedPoints);
        }
    }
}
