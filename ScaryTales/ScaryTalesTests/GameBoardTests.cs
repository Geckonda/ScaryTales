using Moq;
using ScaryTales.Cards;
using ScaryTales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ScaryTales.Enums;

namespace ScaryTalesTests
{
    public class GameBoardTests
    {
        [Fact]
        public void GameBoard_Has_Decks_When_Initialize()
        {
            // Arrange
            var gameBoard = new GameBoard();


            // Assert
            Assert.Equal(0, gameBoard.CardsOnBoardCount());
            Assert.Equal(0, gameBoard.DiscardPileCount());
        }

        [Fact]
        public void CardsOnBoardCount_Should_Increase_When_AddOnBoard()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var card = new NightCard();

            // Act
            gameBoard.AddCardOnBoard(card);

            // Assert
            Assert.Equal(1, gameBoard.CardsOnBoardCount());
        }
        [Fact]
        public void CardsOnBoardCount_Should_Decrease_When_RemoveFromBoard()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var card = new NightCard();

            // Act
            gameBoard.AddCardOnBoard(card);
            gameBoard.RemoveCardFromBoard(card);

            // Assert
            Assert.Equal(0, gameBoard.CardsOnBoardCount());
        }
        [Fact]
        public void DiscardPileCount_Should_Increase_When_AddCardToDiscardPile()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var card = new NightCard();

            // Act
            gameBoard.AddCardToDiscardPile(card);

            // Assert
            Assert.Equal(1, gameBoard.DiscardPileCount());
        }
        [Fact]
        public void CardsOnBoardCount_Should_Decrease_When_MoveCardFromBoardToDiscardPile()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var card = new NightCard();

            // Act
            gameBoard.AddCardOnBoard(card);
            gameBoard.MoveCardFromBoardToDiscardPile(card);

            // Assert
            Assert.Equal(0, gameBoard.CardsOnBoardCount());
        }
        [Fact]
        public void DiscardPileCount_ShouldBe_One_When_MoveCardFromBoardToDiscardPile()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var card = new NightCard();

            // Act
            gameBoard.AddCardOnBoard(card);
            gameBoard.MoveCardFromBoardToDiscardPile(card);

            // Assert
            Assert.Equal(1, gameBoard.DiscardPileCount());
        }

        [Fact]
        public void GetCardsOnBoard_Should_Return_ListOfCards_With_Same_Cards()
        {

            // Arrange
            var gameBoard = new GameBoard();
            var night = new NightCard();
            var day = new DayCard();
            var dragon = new DragonCard();

            var expectedCards = new List<Card> { night, day, dragon };

            // Act
            gameBoard.AddCardOnBoard(night);
            gameBoard.AddCardOnBoard(day);
            gameBoard.AddCardOnBoard(dragon);

            var actualCards = gameBoard.GetCardsOnBoard();

            // Assert
            Assert.Equal(expectedCards, actualCards);
        }
        [Fact]
        public void GetCardsFromDiscardPile_ShouldReturnCardsInOrder()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var night = new NightCard();
            var day = new DayCard();
            var dragon = new DragonCard();

            var expectedCards = new List<Card> { night, day, dragon };

            // Act
            gameBoard.AddCardToDiscardPile(night);
            gameBoard.AddCardToDiscardPile(day);
            gameBoard.AddCardToDiscardPile(dragon);

            var actualCards = gameBoard.GetCardsFromDiscardPile();

            // Assert
            Assert.Equal(expectedCards, actualCards);
        }
        [Fact]
        public void GetCardsOnBoard_Should_Be_Empty_When_There_Are_No_Cards()
        {
            // Arrange
            var gameBoard = new GameBoard();

            // Act

            var listOfCards = gameBoard.GetCardsOnBoard();

            // Assert
            Assert.Empty(listOfCards);
        }
        [Fact]
        public void GetCardsFromDiscardPile_Should_Be_Empty_When_There_Are_No_Cards()
        {
            // Arrange
            var gameBoard = new GameBoard();

            // Act

            var listOfCards = gameBoard.GetCardsFromDiscardPile();

            // Assert
            Assert.Empty(listOfCards);
        }
        [Fact]
        public void GetCardsOnBoard_ShouldReturnCardsOfSpecifiedType()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var night = new NightCard();
            var oldMaster = new OldMasterCard();
            var day = new DayCard();

            // Act
            gameBoard.AddCardOnBoard(day);
            gameBoard.AddCardOnBoard(oldMaster);
            gameBoard.AddCardOnBoard(night);

            var result = gameBoard.GetCardsOnBoard(CardType.Event);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, card => Assert.Equal(CardType.Event, card.Type));
        }

        [Fact]
        public void GetCardsOnBoard_ShouldReturnCardsOfSpecifiedName()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var night1 = new NightCard();
            var night2 = new NightCard();
            var oldMaster = new OldMasterCard();
            var day = new DayCard();

            const string cardName = "Ночь";
            // Act
            gameBoard.AddCardOnBoard(day);
            gameBoard.AddCardOnBoard(oldMaster);
            gameBoard.AddCardOnBoard(night1);
            gameBoard.AddCardOnBoard(night2);

            var result = gameBoard.GetCardsOnBoard(cardName);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, card => Assert.Equal(cardName, card.Name));
        }
    }
}
