using Jarrus.TTT.CPU;
using Xunit;

namespace Jarrus.GamesTests.Players
{
    public class PlayerTests
    {
        [Fact]
        public void ItShouldGetANdSetSeeds()
        {
            var player = new EasyCPU();
            Assert.NotEqual(0, player.GetSeed());

            player.SetSeed(35);
            Assert.Equal(35, player.GetSeed());
        }
    }
}
