using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTalesTests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using ScaryTales.Abstractions;
    using ScaryTales;
    using Xunit;
    using ScaryTales.Cards;
    using ScaryTales.Items;
    using Xunit.Abstractions;

    public class PlayerTests
    {
        [Fact]
        public void Player_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockInput = new Mock<IPlayerInput>();

            // Act
            var player = new Player("TestPlayer", mockInput.Object);

            // Assert
            Assert.Equal("TestPlayer", player.Name);
            Assert.Equal(0, player.Score);
            Assert.Empty(player.Hand);
        }

        [Fact]
        public void AddPoints_ShouldIncreaseScore()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);

            // Act
            player.AddPoints(10);

            // Assert
            Assert.Equal(10, player.Score);
        }
        [Fact]
        public void AddPoints_ShouldThrowExceptionWhenPointsNegative()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => player.AddPoints(-10));
            Assert.Equal("Число должно быть положительным", exception.Message);
        }

        [Fact]
        public void AddCardToHand_ShouldIncreaseHandSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var card = new NightCard();

            // Act
            player.AddCardToHand(card);

            // Assert
            Assert.Single(player.Hand);
            Assert.Contains(card, player.Hand);
        }

        [Fact]
        public void RemoveCorrectCardFromHand_ShouldDecreaseHandSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var card = new NightCard();
            player.AddCardToHand(card);

            // Act
            player.RemoveCardFromHand(card);

            // Assert
            Assert.Empty(player.Hand);
        }
        [Fact]
        public void RemoveWrongCardFromHand_ShouldNotDecreaseHandSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var card1 = new NightCard();
            var card2 = new DayCard();
            player.AddCardToHand(card1);

            // Act
            player.RemoveCardFromHand(card2);

            // Assert
            Assert.Single(player.Hand);
        }
        [Fact]
        public void RemoveCardFromEmptyHand_ShouldNotDecreaseHandSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var card = new NightCard();

            // Act
            player.RemoveCardFromHand(card);

            // Assert
            Assert.Empty(player.Hand);
        }
        [Fact]
        public void HasCard_ShouldReturnTrueIfCardExists()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var card = new NightCard();
            player.AddCardToHand(card);

            // Act & Assert
            Assert.True(player.HasCard(card));
        }

        [Fact]
        public void HasCard_ShouldReturnFalseIfCardDoesNotExist()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var card = new NightCard();

            // Act & Assert
            Assert.False(player.HasCard(card));
        }

        [Fact]
        public void SelectCardInHand_ShouldReturnCorrectCard()
        {
            // Arrange
            var mockInput = new Mock<IPlayerInput>();
            var player = new Player("TestPlayer", mockInput.Object);
            var card = new NightCard();
            player.AddCardToHand(card);

            mockInput.Setup(i => i.SelectCard(It.IsAny<List<Card>>())).Returns(card);

            // Act
            var selectedCard = player.SelectCardInHand();

            // Assert
            Assert.Equal(card, selectedCard);
        }

        [Fact]
        public void SelectCardAmongOthers_ShouldReturnCorrectCard()
        {
            // Arrange
            var mockInput = new Mock<IPlayerInput>();
            var player = new Player("TestPlayer", mockInput.Object);
            var card1 = new NightCard();
            var card2 = new DayCard();
            var cards = new List<Card> { card1, card2 };

            mockInput.Setup(i => i.SelectCard(cards)).Returns(card2);

            // Act
            var selectedCard = player.SelectCardAmongOthers(cards);

            // Assert
            Assert.Equal(card2, selectedCard);
        }

        [Fact]
        public void AddItemToItemBag_ShouldIncreaseItemBagSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var item = new Armor();

            // Act
            player.AddItemToItemBag(item);

            // Assert
            Assert.Equal(1, player.ItemsBagCount);
        }

        [Fact]
        public void RemoveCorrectItemFromItemBag_ShouldDecreaseItemBagSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var item = new Armor();
            player.AddItemToItemBag(item);

            // Act
            player.RemoveItemFromItemBag(item);

            // Assert
            Assert.Equal(0, player.ItemsBagCount);
        }
        [Fact]
        public void RemoveWrongItemFromItemBag_ShouldNotDecreaseItemBagSize()
        {
            // Arrange
            var player = new Player("TestPlayer", new Mock<IPlayerInput>().Object);
            var item1 = new Armor();
            var item2 = new Sword();
            player.AddItemToItemBag(item1);

            // Act
            player.RemoveItemFromItemBag(item2);

            // Assert
            Assert.Equal(1, player.ItemsBagCount);
        }

        [Fact]
        public void SelectItem_ShouldReturnCorrectItem()
        {
            // Arrange
            var mockInput = new Mock<IPlayerInput>();
            var player = new Player("TestPlayer", mockInput.Object);
            var item1 = new Armor();
            var item2 = new Sword();
            var items = new List<Item> { item1, item2 };

            mockInput.Setup(i => i.SelectItem(items)).Returns(item1);

            // Act
            var selectedItem = player.SelectItem(items);

            // Assert
            Assert.Equal(item1, selectedItem);
        }
        [Fact]
        public void HasItem_ShouldReturnTrueIfPlayerHasItem()
        {
            // Arrange
            var mockInput = new Mock<IPlayerInput>();
            var player = new Player("TestPlayer", mockInput.Object);
            var item = new Armor();
            player.AddItemToItemBag(item);

            // Act
            var hasItem = player.HasItem(item);

            // Assert
            Assert.True(hasItem);
        }
        [Fact]
        public void HasItem_ShouldReturnFalseIfPlayerDoesNotHaveItem()
        {
            // Arrange
            var mockInput = new Mock<IPlayerInput>();
            var player = new Player("TestPlayer", mockInput.Object);
            var item1 = new Armor();
            var item2 = new Sword();
            player.AddItemToItemBag(item1);

            // Act
            var hasItem = player.HasItem(item2);

            // Assert
            Assert.False(hasItem);
        }
    }

}
