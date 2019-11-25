using Jarrus.Games.Cards;
using Xunit;

namespace Jarrus.GamesTests.Cards
{
    public class PlayingCardTests
    {
        [Fact]
        public void ItShouldDetermineIfEqual()
        {
            var deck = new StandardDeck();

            var card = deck.Get();

            Assert.Equal(card.Suit, Suit.SPADE);
            Assert.Equal(card.Card, Card.ACE);

            var playingCard = new PlayingCard(Suit.SPADE, 1, Card.ACE);

            Assert.Equal(card, playingCard);
        }

        [Fact]
        public void ItShouldHaveDisplayableString()
        {
            var playingCard = new PlayingCard(Suit.SPADE, 1, Card.ACE);
            Assert.Equal("Ace of Spades", playingCard.ToString());
        }
    }
}
