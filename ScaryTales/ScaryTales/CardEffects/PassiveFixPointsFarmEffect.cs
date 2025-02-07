using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.CardEffects
{
    /// <summary>
    /// Эффект, позхволяивающйи накапливать фиксированное количество ПО
    /// </summary>
    public class PassiveFixPointsFarmEffect : ICardEffect
    {
        private readonly int _points;
        /// <summary>
        /// Создает эффект фиксированной добычи ПО
        /// </summary>
        /// <param name="points">Размер ПО</param>
        public PassiveFixPointsFarmEffect(int points)
        {
            _points = points;
        }
        public CardEffectTimeApply EffectTime => CardEffectTimeApply.PassiveIncome;

        public CardEffectType Type => CardEffectType.PassiveFarmAtTheEnd;

        public void ApplyEffect(IGameState gameState, IGameBoard gameBoard)
        {
            var player = gameState.GetCurrentPlayer();
            gameState.Notificate($"Игрок {player.Name} получает {_points} ПО.");
            player.AddPoints(_points);
        }
    }
}
