using Jarrus.Games;
using Jarrus.TTT;
using Xunit;

namespace Jarrus.TTTTests
{
    public class BoardTests
    {
        [Fact]
        public void ItShouldStartWithAnEmptyBoard()
        {
            var board = new Board();
            Assert.Equal("EEEEEEEEE", board.ToString());
        }

        [Fact]
        public void ItShouldProcessAMove()
        {
            var board = new Board();
            board.Process(new Move(0, 1));

            Assert.Equal("EXEEEEEEE", board.ToString());
        }
    }
}
