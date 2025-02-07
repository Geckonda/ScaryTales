using ScaryTales.Abstractions;
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
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.Immediately;

        public CardEffectType Type => CardEffectType.Instant;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {
            var monsters = gameBoard.GetCardsOnBoardByType(CardType.Monster);
            int earnedPoints = monsters.Count << 1;
            var player = gameState.GetCurrentPlayer();
            gameState.Notificate($"Игрок {player.Name} заработал {earnedPoints} ПО");
            player.AddPoints(earnedPoints);

            // Пользователь выбирает карту на сброс
            var places = gameBoard.GetCardsOnBoardByType(CardType.Place);
            if (!places.Any())
            {
                Console.WriteLine("Нет ни одной карты 'Место' на столе");
                return;
            }
            Printer.PrintCardList(places, gameState.Notificate, "Место");
            var index = int.Parse(Console.ReadLine()!) - 1;
            var place = places[index];
            gameState.Notificate($"Игрок {player.Name} сбросил карту {place.Name}");
            player.DiscardCardFromBoard(place);
            // !!! Костыль
        }
    }
}
