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
    public class DragonEffect : ICardEffect
    {
        public CardEffectTimeType Type => CardEffectTimeType.Instant;

        public void ApplyEffect(IGameContext context)
        {
            var state = context.GameState;
            var board = context.GameBoard;
            var manager = context.GameManager;

            var places = board.GetCardsOnBoard(CardType.Place);
            var men = board.GetCardsOnBoard(CardType.Man);

            if (places.Any() && men.Any())
            {
                manager.PrintMessage("Не нашлось ни одной карты для сброса.");
                return;
            }
            var player = state.GetCurrentPlayer();
            if (!places.Any())
                manager.PrintMessage("Нет ни одной карты типа 'Место' на столе");
            else
            {
                Printer.PrintCardList(places, manager.PrintMessage, "Место");
                var place = player.SelectCardAmongOthers(places);
                manager.PrintMessage($"Игрок {player.Name} сбросил карту {place.Name}");
                board.RemoveCardFromBoard(place);
                manager.PutCardToDiscardPile(place);
                manager.AddPointsToPlayer(player, 2);
            }
            if (!men.Any())
                manager.PrintMessage("Нет ни одной карты типа 'Мужчина' на столе");
            else
            {
                Printer.PrintCardList(men, manager.PrintMessage, "Мужчина");
                var man = player.SelectCardAmongOthers(men);
                manager.PrintMessage($"Игрок {player.Name} сбросил карту {man.Name}");
                board.RemoveCardFromBoard(man);
                manager.PutCardToDiscardPile(man);
                manager.AddPointsToPlayer(player, 2);
            }
        }
    }
}
