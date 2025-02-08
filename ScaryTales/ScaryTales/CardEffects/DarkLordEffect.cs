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
    public class DarkLordEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public void ApplyEffect(IGameContext context)
        {
            var state = context.GameState;
            var board = context.GameBoard;
            var manager = context.GameManager;
            var player = state.GetCurrentPlayer();

            var monsters = board.GetCardsOnBoard(CardType.Monster);
            int earnedPoints = monsters.Count << 1;
            manager.AddPointsToPlayer(player, earnedPoints);

            var places = board.GetCardsOnBoard(CardType.Place);
            if (!places.Any())
            {
                manager.PrintMessage("Нет ни одной карты 'Место' на столе");
                return;
            }
            Printer.PrintCardList(places,
                manager.PrintMessage, "Место");
            var place = player.SelectCardAmongOthers(places);
            manager.PrintMessage($"Игрок {player.Name} сбросил карту {place.Name}");
            board.RemoveCardFromBoard(place);
            manager.PutCardToDiscardPile(place);
        }
    }
}
