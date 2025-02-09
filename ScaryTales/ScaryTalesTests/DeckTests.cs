using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTalesTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using ScaryTales;
    using ScaryTales.Cards;
    using Xunit;

    public class DeckTests
    {
        [Fact]
        public void Deck_Constructor_ShouldCreateDeckWithCorrectCards()
        {
            // Arrange
            var cardMock = new Mock<Card>();
            var card = new NightChildCard();
            cardMock.SetupGet(c => c.CardCountInDeck).Returns(2);
            cardMock.Setup(c => c.Clone()).Returns(card);

            var templates = new List<Card> { cardMock.Object };

            // Act
            var deck = new Deck(templates);

            // Assert
            Assert.Equal(card.CardCountInDeck, deck.CardsRemaining);
        }

        [Fact]
        public void Shuffle_ShouldChangeCardOrder()
        {
            // Arrange
            var templates = new List<Card>
            {
                new NightChildCard(),
                new OldMasterCard(),
                new DarkLordCard(),
                new DragonCard(),
                new EnchantedForestCard(),
                new PrincessCard(),
                new MerchantCard(),
                new WizardCard(),
                new NightCard(),
                new DayCard(),
                new OgreCard(),
                new WisdomKingCard(),
                new FollyKingCard(),
                new FairyCard(),
                new YoungHeroCard(),
                new HiddenCaveCard(),
                new CursedCastleCard(),
                new CharmCard(),
            };

            var deck = new Deck(templates);

            // Act
            var originalOrder = deck.DrawCard()?.Name;
            deck.Shuffle();
            var newOrder = deck.DrawCard()?.Name;

            // Assert
            Assert.NotEqual(originalOrder, newOrder);
        }

        [Fact]
        public void DrawCard_ShouldReturnCardAndDecreaseCount()
        {
            var card = new CharmCard();
            // Arrange
            var templates = new List<Card> { card };
            var deck = new Deck(templates);

            // Act
            var drawnCard = deck.DrawCard();

            // Assert
            Assert.NotNull(drawnCard);
            Assert.Equal(card.Name, drawnCard.Name);
            Assert.Equal(deck.CountDeckInitial - 1, deck.CardsRemaining);
        }

        [Fact]
        public void DrawCard_ShouldReturnNull_WhenDeckIsEmpty()
        {
            // Arrange
            var deck = new Deck(new List<Card>());

            // Act
            var card = deck.DrawCard();

            // Assert
            Assert.Null(card);
        }

        [Fact]
        public void TakeCardByName_ShouldReturnCorrectCardAndRemoveIt()
        {
            var nightChild = new NightChildCard();
            // Arrange
            var templates = new List<Card>
            {
                new OldMasterCard(),
                new NightChildCard(),
                new CharmCard(),
            };
            var deck = new Deck(templates);
            // Act
            var card = deck.TakeCardByName(nightChild.Name);

            // Assert
            Assert.NotNull(card);
            Assert.Equal(nightChild.Name, card.Name);
            Assert.Equal(deck.CountDeckInitial - 1, deck.CardsRemaining);
        }

        [Fact]
        public void TakeCardByName_ShouldReturnNull_IfCardNotFound()
        {
            // Arrange
            var templates = new List<Card> { new CharmCard() };
            var deck = new Deck(templates);

            // Act
            var card = deck.TakeCardByName("Lightning Strike");

            // Assert
            Assert.Null(card);
            Assert.Equal(deck.CountDeckInitial, deck.CardsRemaining);
        }
        [Fact]
        public void TakeCardByName_ShouldReturnNull_IfDeckIsEmpty()
        {
            // Arrange
            var templates = new List<Card> { };
            var deck = new Deck(templates);

            // Act
            var card = deck.TakeCardByName("Lightning Strike");

            // Assert
            Assert.Null(card);
            Assert.Equal(deck.CountDeckInitial, deck.CardsRemaining);
        }
    }

}
