using Jarrus.TTT;
using Jarrus.TTT.CPU;
using System;
using Xunit;

namespace Jarrus.TTTTests.CPU
{
    public class HardCPUTests : IDisposable
    {
        public HardCPU Player1 = new HardCPU();
        public HardCPU Player2 = new HardCPU();
        public TicTacToeGame Game;

        public HardCPUTests()
        {
            Game = TTTHelper.GetGame(Player1, Player2);
        }

        public void Dispose()
        {
            Player1 = null;
            Player2 = null;
        }

        [Fact]
        public void ItShouldPlay()
        {
            Game.Start();
            var board = Game.ToString();

            Assert.Equal("XXOOOXXXO", board);
        }

        [Fact]
        public void ItShouldTakeWin()
        {
            var tttState = (State)Game.State;
            tttState.Set("EEEXXEEEE");

            Game.Start();
            Assert.Equal("EEEXXXEEE", Game.ToString());
        }

        [Fact]
        public void ItShouldBlockWin()
        {
            var tttState = (State)Game.State;
            tttState.Set("EEEOOEEEE");

            Game.Start();
            Assert.Equal("OXOOOXXEO", Game.ToString());
        }
    }
}
