using ScaryTales.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameManager
    {
        private List<Player> _players;          // Список игроков
        private int _currentPlayerIndex;        // Индекс текущего игрока
        private GameBoard _gameBoard;           // Игровое поле
        private Deck _deck;                     // Общая колода
        public MessageHandler _logAction { get; set; } // Делегат для вывода сообщений

        public GameManager(List<Player> players, Deck deck, GameBoard gameBoard, MessageHandler output)
        {
            _players = players;
            _deck = deck;
            _gameBoard = gameBoard;
            _logAction = output;
            _currentPlayerIndex = new Random().Next(0, players.Count);
        }

        // Метод для начала игры
        public void StartGame()
        {
            _logAction?.Invoke("Игра началась!");
            DrawCardsToPlayersHand();

            var currentPlayer = _players[_currentPlayerIndex];
            _logAction?.Invoke($"{currentPlayer.Name} начинает хож первым.");

            StartTurn();
        }
        private void DrawCardsToPlayersHand()
        {
            foreach (var player in _players)
            {
                // Начальная раздача карт
                for (int i = 0; i < 5; i++) // Например, 5 карт каждому игроку
                {
                    player.DrawCard();
                }
            }
        }
        // Метод для начала хода текущего игрока
        public void StartTurn()
        {
            Player currentPlayer = _players[_currentPlayerIndex];
            _logAction?.Invoke($"{currentPlayer.Name} начинает ход.");
            // Логика начала хода (например, вытягивание карты, проверка эффектов и т.д.)
            _gameBoard.ShowCardsOnBoard();
            currentPlayer.DrawCard();
            currentPlayer.ShowHand();
            var card = currentPlayer.PlayCard(int.Parse(Console.ReadLine()!) - 1);
            EndTurn();
        }


        // Метод для завершения хода текущего игрока
        public void EndTurn()
        {
            Player currentPlayer = _players[_currentPlayerIndex];
            _logAction?.Invoke($"{currentPlayer.Name} завершает ход.");


            // Подсчёт и назначение очков игроку
            //int pointsEarned = CalculatePoints(currentPlayer);
            //_logAction?.Invoke($"{currentPlayer.Name} получает {pointsEarned} очков.");
            //currentPlayer.AddPoints(pointsEarned);

            // Проверка окончания игры или переход к следующему ходу
            if (IsGameOver(currentPlayer))
            {
                EndGame();
            }
            else
            {
                // Переход к следующему игроку
                _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
                StartTurn();
            }

        }

        // Метод для подсчёта очков игрока по завершению хода
        private void CalculatePoints(Player player)
        {
            var cards = _gameBoard.GetPlayerCardsOnBoard(player);
            var result = 0;
            foreach (var card in cards)
            {
                if(card.EffectTimeApply == CardEffectTimeApply.PassiveIncome)
                    card.ActivateEffect(_gameBoard);

            }
        }

        // Метод для проверки окончания игры
        private bool IsGameOver(Player player)
        {
            if (player.HandCount == 0 && _deck.CardsRemaining == 0)
                return true;
            return false;
        }

        // Метод для завершения игры
        private void EndGame()
        {
            _logAction?.Invoke("Игра закончена!");

            // Определение победителя (например, игрок с наибольшим количеством очков)
            Player? winner = null;
            int highestScore = int.MinValue;

            foreach (var player in _players)
            {
                if (player.Score > highestScore)
                {
                    highestScore = player.Score;
                    winner = player;
                }
            }

            if (winner != null)
            {
                _logAction?.Invoke($"Победитель: {winner.Name} с {winner.Score} очками!");
            }
            else
            {
                _logAction?.Invoke("Ничья!");
            }
        }
    }
}
