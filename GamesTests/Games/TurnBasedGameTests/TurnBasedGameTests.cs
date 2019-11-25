using Jarrus.TTT.CPU;
using Jarrus.TTTTests;
using Xunit;

namespace Jarrus.GamesTests.Games.TurnBasedGameTests
{
    public class TurnBasedGameTests
    {
        [Fact]
        public void ItShouldStartTheGame()
        {
            var game = TTTHelper.GetGame(new EasyCPU(), new EasyCPU());
            game.Start();

            var board = game.ToString();
            Assert.Equal("XOXOXOXEE", board);
        }
    }
}
