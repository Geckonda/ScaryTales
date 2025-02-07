using ScaryTales.Abstractions;
using ScaryTales.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    public class DragonEffect : ICardEffect
    {
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.Immediately;

        public CardEffectType Type => CardEffectType.Instant;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {
            var places = gameBoard.GetCardsOnBoardByType(CardType.Place);
            var men = gameBoard.GetCardsOnBoardByType(CardType.Man);
            if (places.Any() && men.Any())
            {
                gameState.Notificate("Не нашлось ни одной карты для сброса.");
                return;
            }
            var player = gameState.GetCurrentPlayer();
            if (!places.Any())
                gameState.Notificate("Нет ни одной карты 'Место' на столе");
            else
            {
                Printer.PrintCardList(places, gameState.Notificate, "Место");
                var index = int.Parse(Console.ReadLine()!) - 1;
                var place = places[index];
                gameState.Notificate($"Игрок {player.Name} сбросил карту {place.Name}");
                player.DiscardCardFromBoard(place);
                player.AddPoints(2);
                gameState.Notificate($"Игрок {player.Name} получил 2 ПО.");
            }
            if (!men.Any())
                gameState.Notificate("Нет ни одной карты 'Мужчина' на столе");
            else
            {
                Printer.PrintCardList(men, gameState.Notificate, "Мужчина");
                var index = int.Parse(Console.ReadLine()!) - 1;
                var man = men[index];
                gameState.Notificate($"Игрок {player.Name} сбросил карту {man.Name}");
                player.DiscardCardFromBoard(man);
                player.AddPoints(2);
                gameState.Notificate($"Игрок {player.Name} получил 2 ПО");
            }

        }
    }
}
