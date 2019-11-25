using Jarrus.Games.Cards;
using System;
using Xunit;

namespace Jarrus.GamesTests.Cards
{
    public class DeckTests : IDisposable
    {
        public StandardDeck Deck;

        public DeckTests() { Deck = new StandardDeck(); }
        public void Dispose() { Deck = null; }

        [Fact]
        public void ItShouldSetARandomInitialSeed()
        {
            Assert.NotEqual(0, Deck.GetSeed());
        }

        [Fact]
        public void ItShouldSetTheSeed()
        {
            Deck.SetSeed(35);
            var firstCard = Deck.GetRandomCard();

            Deck.SetSeed(35);
            var secondCard = Deck.GetRandomCard();

            Assert.Equal(firstCard, secondCard);
        }

        [Fact]
        public void ItShouldGetARandomCard()
        {
            Deck.SetSeed(35);
            var firstCard = Deck.GetRandomCard();

            Deck.SetSeed(22);
            var secondCard = Deck.GetRandomCard();

            Assert.NotEqual(firstCard, secondCard);
        }

        [Fact]
        public void ItShouldShuffle()
        {
            Deck.SetSeed(35);
            var firstCard = Deck.Get(0);

            Deck.Shuffle();
            var topCard = Deck.Get(0);

            Assert.NotEqual(topCard, firstCard);
        }

        [Fact]
        public void ItShouldCutTheDeck()
        {
            var topCard = Deck.Get(0);
            var sixteenthCard = Deck.Get(15);

            Deck.Cut(15);

            var cutTopCard = Deck.Get(0);

            Assert.Equal(cutTopCard, sixteenthCard);
            Assert.NotEqual(topCard, cutTopCard);
        }

        [Fact]
        public void ItShouldNotCutIfNumberTooLow()
        {
            var topCard = Deck.Get(0);

            Deck.Cut(-1);

            Assert.Equal(topCard, Deck.Get(0));
        }

        [Fact]
        public void ItShouldNotCutIfNumberTooHigh()
        {
            var topCard = Deck.Get(0);

            Deck.Cut(52);

            Assert.Equal(topCard, Deck.Get(0));
        }
    }
}
