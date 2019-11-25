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
            Game = TTTHelper.GetGame(new EasyCPU(), new EasyCPU());
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

            Assert.Equal("OXXOXOXEE", Game.ToString());
        }

        [Fact]
        public void ItShouldThrowAnExceptionIfInvalidMoveRequested()
        {
            Game.Process(new Action(Seat.ONE, 1));

            Assert.Throws<InvalidMoveException>(() => Game.Process(new Action(Seat.ONE, 1)));
        }
    }
}
