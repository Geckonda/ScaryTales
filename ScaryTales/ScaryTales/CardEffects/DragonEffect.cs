using ScaryTales.Abstractions;
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
            var monsters = gameBoard.GetCardsOnBoard()
               .Where(x => x.Type == CardType.Monster).ToList();
            var men = gameBoard.GetCardsOnBoard()
               .Where(x => x.Type == CardType.Man).ToList();
            if (monsters.Any() && men.Any())
            {
                gameState.Notificate("Не нашлось ни одной карты для сброса.");
                return;
            }
            var player = gameState.GetCurrentPlayer();
            if (!monsters.Any())
                gameState.Notificate("Нет ни одной карты 'Злодей' на столе");
            else
            {
                PrintCards(monsters, gameState.Notificate, "Злодей");
                var index = int.Parse(Console.ReadLine()!) - 1;
                var monster = monsters[index];
                gameState.Notificate($"Игрок {player.Name} сбросил карту {monster.Name}");
                player.DiscardCardFromBoard(monster);
                player.AddPoints(2);
                gameState.Notificate($"Игрок {player.Name} получил 2 ПО");
            }
            if (!men.Any())
                gameState.Notificate("Нет ни одной карты 'Мужчина' на столе");
            else
            {
                PrintCards(men, gameState.Notificate, "Мужчина");
                var index = int.Parse(Console.ReadLine()!) - 1;
                var man = men[index];
                gameState.Notificate($"Игрок {player.Name} сбросил карту {man.Name}");
                player.DiscardCardFromBoard(man);
                player.AddPoints(2);
                gameState.Notificate($"Игрок {player.Name} получил 2 ПО");
            }

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
