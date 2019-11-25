using Jarrus.Games.Cards;
using Xunit;

namespace Jarrus.GamesTests.Cards
{
    public class StandardDeckTests
    {
        [Fact]
        public void ItShouldHave52Cards()
        {
            var deck = new StandardDeck();
            Assert.Equal(52, deck.Count());
        }

        [Fact]
        public void ItShouldInitializeProperly()
        {
            var deck = new StandardDeck();

            foreach (var card in deck.GetCards())
            {
                Assert.True(card != null);
            }
        }

        [Fact]
        public void ItShouldHave13OfEachCard()
        {
            var deck = new StandardDeck();

            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.ACE));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.TWO));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.THREE));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.FOUR));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.FIVE));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.SIX));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.SEVEN));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.EIGHT));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.NINE));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.TEN));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.JACK));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.QUEEN));
            Assert.Equal(4, CardTestHelper.GetNumberOfCards(deck, Card.KING));
        }

        [Fact]
        public void ItShouldHave4OfEachSuit()
        {
            var deck = new StandardDeck();

            Assert.Equal(13, CardTestHelper.GetNumberOfCards(deck, Suit.SPADE));
            Assert.Equal(13, CardTestHelper.GetNumberOfCards(deck, Suit.HEART));
            Assert.Equal(13, CardTestHelper.GetNumberOfCards(deck, Suit.DIAMOND));
            Assert.Equal(13, CardTestHelper.GetNumberOfCards(deck, Suit.CLUB));
        }
    }
}
