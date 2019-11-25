using System;
using System.Linq;
using Xunit;

namespace Jarrus.GamesTests.Cards.Tricks
{
    public class TrickBasedStateTests : IDisposable
    {
        public SimpleTrickBasedState Mat;

        public TrickBasedStateTests()
        {
            Mat = new SimpleTrickBasedState();
        }

        public void Dispose() { Mat = null; }

        [Fact]
        public void ItShouldDealCards()
        {
            Mat.DealOut(1);

            for(int i = 0; i < 4; i++)
            {
                var hand = Mat.GetHands()[i];
                Assert.Equal(1, (int) hand.Cards.Count());
            }

            Assert.Equal(4, Mat.GetCardIndex());
        }

        [Fact]
        public void ItShouldShuffleAndReset()
        {
            Mat.ShuffleUp();
            Mat.DealOut(1);

            for (int i = 0; i < 4; i++)
            {
                var hand = Mat.GetHands()[i];
                Assert.Equal(1, (int)hand.Cards.Count());
            }

            Assert.Equal(4, Mat.GetCardIndex());

            Mat.ShuffleUp();

            for (int i = 0; i < 4; i++)
            {
                var hand = Mat.GetHands()[i];
                Assert.Equal(0, (int)hand.Cards.Count());
            }

            Assert.Equal(0, Mat.GetCardIndex());
        }

        [Fact]
        public void ItShouldPlayACard()
        {
            Mat.ShuffleUp();
            Mat.DealOut(12);

            foreach(var player in Mat.GetHands())
            {
                Mat.Play(player.Seat, player.Cards[0]);
            }

            Assert.Equal(4, (int)Mat.GetBoard().Count());
        }

        [Fact]
        public void ItShouldTakeATrickWhenAllPlayersPlay()
        {
            Mat.ShuffleUp();
            Mat.DealOut(12);

            foreach (var player in Mat.GetHands())
            {
                Mat.Play(player.Seat, player.Cards[0]);
            }

            //Assert.Equal(1, Mat.Tricks)
        }
    }
}
