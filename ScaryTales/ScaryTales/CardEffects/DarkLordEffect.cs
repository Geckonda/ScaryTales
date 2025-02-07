using ScaryTales.Abstractions;
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
            var monsters = gameBoard.GetCardsOnBoard()
                .Where(x => x.Type == CardType.Monster).ToList();
            int earnedPoints = monsters.Count << 1;
            var player = gameState.GetCurrentPlayer();
            gameState.Notificate($"Игрок {player.Name} заработал {earnedPoints} ПО");
            player.AddPoints(earnedPoints);

            // Пользователь выбирает карту на сброс
            var places = gameBoard.GetCardsOnBoard()
                .Where(x => x.Type == CardType.Place).ToList();
            if (!places.Any())
            {
                Console.WriteLine("Нет ни одной карты 'Место' на столе");
                return;
            }
            PrintCards(places, gameState.Notificate, "Место");
            var index = int.Parse(Console.ReadLine()!) - 1;
            var place = places[index];
            gameState.Notificate($"Игрок {player.Name} сбросил карту {place.Name}");
            player.DiscardCardFromBoard(place);
            // !!! Костыль
        }

        private void PrintCards(List<Card> cards,
            Action<string> notificate,
            string cardType)
        {
            var card = cards.FirstOrDefault();
            notificate($"Карты типа {cardType}");
            for (int i = 0; i < cards.Count; i++)
            {
                notificate($"{i + 1} - {cards[i].Name}");
            }
        }
    }
}
