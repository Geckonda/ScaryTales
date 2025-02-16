using ScaryTales.Abstractions;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class OgreEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public void ApplyEffect(IGameContext context)
        {
            var state = context.GameState;
            var board = context.GameBoard;
            var manager = context.GameManager;
            var player = state.GetCurrentPlayer();

            var places = board.GetCardsOnBoard(CardType.Place);
            var women = board.GetCardsOnBoard(CardType.Woman);
            if (!places.Any() && !women.Any())
            {
                manager.PrintMessage("Не нашлось ни одной карты для сброса.");
                return;
            }
            if (!places.Any())
            {
                manager.PrintMessage("Нет ни одной карты типа 'Место' на столе.");
            }
            else
            {
                var place = player.SelectCardAmongOthers(places);
                board.RemoveCardFromBoard(place);
                manager.PutCardInPlayerHand(place, player);
            }

            if (!women.Any())
            {
                manager.PrintMessage("Нет ни одной карты типа 'Женщина' на столе.");
            }
            else
            {
                var woman = player.SelectCardAmongOthers(women);
                board.RemoveCardFromBoard(woman);
                manager.PutCardInPlayerHand(woman, player);
            }
        }
    }
}
