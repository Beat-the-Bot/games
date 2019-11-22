using Jarrus.Games;
using Jarrus.Games.Enums;
using Jarrus.Games.Exceptions;
using Jarrus.TTT;
using Xunit;

namespace Jarrus.TTTTests
{
    public class TicTacToeGameTests
    {
        [Fact]
        public void ItShouldStartWithAnEmptyBoard()
        {
            var game = new TicTacToeGame();
            Assert.Equal("EEEEEEEEE", game.ToString());
        }

        [Fact]
        public void ItShouldProcessAMove()
        {
            var game = new TicTacToeGame();
            game.Process(new Action(Seat.ONE, 1));

            Assert.Equal("EXEEEEEEE", game.ToString());
        }

        [Fact]
        public void ItShouldThrowAnExceptionIfInvalidMoveRequested()
        {
            var game = new TicTacToeGame();
            game.Process(new Action(Seat.ONE, 1));

            Assert.Throws<InvalidMoveException>(() => game.Process(new Action(Seat.ONE, 1)));
        }
    }
}
