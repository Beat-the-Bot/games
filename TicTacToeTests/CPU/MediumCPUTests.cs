using Jarrus.TTT;
using Jarrus.TTT.CPU;
using System;
using Xunit;

namespace Jarrus.TTTTests.CPU
{
    public class MediumCPUTests : IDisposable
    {
        public MediumCPU Player1 = new MediumCPU();
        public MediumCPU Player2 = new MediumCPU();
        public TicTacToeGame Game;

        public MediumCPUTests()
        {
            Game = TTTHelper.GetGame(Player1, Player2);
        }

        public void Dispose()
        {
            Player1 = null;
            Player2 = null;
        }

        [Fact]
        public void ItShouldRandomlyPlay()
        {
            Player1.SetSeed(35);
            Player2.SetSeed(1);

            Game.Start();
            var board = Game.ToString();

            Assert.Equal("XXOEOXOEE", board);
        }
    }
}
