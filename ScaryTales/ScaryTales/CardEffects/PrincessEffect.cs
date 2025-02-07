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
    public class PrincessEffect : ICardEffect
    {
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.Immediately;

        public CardEffectType Type => CardEffectType.Instant;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {
            var men = gameBoard.GetCardsOnBoardByType(CardType.Man);
            if (!men.Any())
            {
                Console.WriteLine("Нет ни одной карты типа 'Мужчина' на столе.");
                return;
            }
            Printer.PrintCardList(men, gameState.Notificate, "Мужчина");
            var index = int.Parse(Console.ReadLine()!) - 1;
            var man = men[index];
            var player = gameState.GetCurrentPlayer();
            player.PutCardFromBoardInHand(man);
        }
    }
}
