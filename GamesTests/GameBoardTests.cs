using Jarrus.TTT;
using Xunit;

namespace Jarrus.GamesTests
{
    public class GameBoardTests
    {
        [Fact]
        public void ItShouldShowAMeaningfulBoardAsAString()
        {
            var board = new Board();
            Assert.Equal("EEEEEEEEE", board.ToString());
        }
    }
}
