using ScaryTales.Abstractions;
using ScaryTales.Cards;
using ScaryTales.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales
{
    public class GameBoard : IGameBoard
    {
        /// <summary>
        /// Карты в данный момент разыгранные на столе
        /// </summary>
        private List<Card> _cardsOnBoard;
        /// <summary>
        /// Карты, сброшенные в колоду сброса
        /// </summary>
        private List<Card> _discardPile;
        /// <summary>
        /// Карта времени суток
        /// </summary>
        private Card? _timeOfDay;
        public GameBoard()
        {
            _cardsOnBoard = new List<Card>();
            _discardPile = new List<Card>();
        }

        public void AddCardOnBoard(Card card) => _cardsOnBoard.Add(card);

        public void MoveCardFromBoardToDiscardPile(Card card)
        {
            _cardsOnBoard.Remove(card);
            _discardPile.Add(card);
        }

        public int CardsOnBoardCount() => _cardsOnBoard.Count;

        public int DiscardPileCount() => _discardPile.Count;

        public List<Card> GetCardsFromDiscardPile() => _discardPile;

        public List<Card> GetCardsOnBoard() => _cardsOnBoard;

        public List<Card> GetCardsOnBoard(CardType type)
        {
            return _cardsOnBoard.Where(x => x.Type == type).ToList();
        }
        public List<Card> GetCardsOnBoard(string name)
        {
            return _cardsOnBoard.Where(x => x.Name == name).ToList();
        }
        public List<Card> GetCardsOnBoard(Player player)
        {
            return _cardsOnBoard.Where(x => x.Owner == player).ToList();
        }
        public void MoveAllCardsToDiscardPile()
        {
            foreach (var card in _cardsOnBoard)
            {
                MoveCardFromBoardToDiscardPile(card);
            }
            _cardsOnBoard.Clear();
        }

        public void RemoveCardFromBoard(Card card) => _cardsOnBoard.Remove(card);

        public void AddCardToDiscardPile(Card card) => _discardPile.Add(card);

        public void SetTimeOfDaySlot(Card card)
        {
            if(card is DayCard || card is NightCard)
                _timeOfDay = card;
        }

        public Card? GetCardFormTimeOfDaySlot() => _timeOfDay;
    }
}
