using System;
using System.Linq;
using Xunit;

namespace Jarrus.GamesTests.Cards
{
    public class StandardCatMatStateTests : IDisposable
    {
        public SimpleCardMat Mat;

        public StandardCatMatStateTests()
        {
            Mat = new SimpleCardMat();
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
    }
}
