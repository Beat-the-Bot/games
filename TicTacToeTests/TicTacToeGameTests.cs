using Jarrus.Games.Enums;
using Jarrus.Games.Exceptions;
using Jarrus.TTT;
using Jarrus.TTT.CPU;
using System;
using Xunit;
using Action = Jarrus.TTT.Action;

namespace Jarrus.TTTTests
{
    public class TicTacToeGameTests : IDisposable
    {
        public TicTacToeGame Game;
        public TicTacToeGameTests()
        {
            Game = new TicTacToeGame();
            SetupGame();
        }

        public void Dispose() { Game = null; }

        [Fact]
        public void ItShouldStartWithAnEmptyBoard()
        {
            Assert.Equal("EEEEEEEEE", Game.ToString());
        }

        [Fact]
        public void ItShouldProcessAMove()
        {
            Game.Process(new Action(Seat.ONE, 1));

            Assert.Equal("EXEEEEEEE", Game.ToString());
        }

        [Fact]
        public void ItShouldThrowAnExceptionIfInvalidMoveRequested()
        {
            Game.Process(new Action(Seat.ONE, 1));

            Assert.Throws<InvalidMoveException>(() => Game.Process(new Action(Seat.ONE, 1)));
        }

        [Fact]
        public void ItShouldStartTheGame()
        {
            Game.Start();

            var board = Game.ToString();
            Assert.Equal("XOXOXOXEE", board);
        }

        private void SetupGame()
        {
            var player1 = new EasyAgent();
            var player2 = new EasyAgent();

            player1.Join(Game);
            player2.Join(Game);

            player1.Sit();
            player1.Ready();

            player2.Sit();
            player2.Ready();
        }
    }
}
