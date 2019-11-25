using Jarrus.Games.Enums;
using Jarrus.TTT;
using System;
using Xunit;

namespace Jarrus.TTTTests
{
    public class StateTests
    {
        private static Random _random = new Random();
        private const string allowedChars = "EXO";

        [Fact]
        public void ItShouldValidateTheStringLength()
        {
            var state = new State();

            for(int i = 0; i < State.SIZE; i++)
            {
                Assert.Throws<ArgumentException>(() => state.Set(CreateString(i)));
            }

            for (int i = State.SIZE + 1; i < 100; i++)
            {
                Assert.Throws<ArgumentException>(() => state.Set(CreateString(i)));
            }
        }

        [Fact]
        public void ItShouldSetTheState()
        {
            var state = new State();
            state.Set("XXXOEOEOE");

            Assert.Equal("XXXOEOEOE", state.ToString());
        }

        [Fact]
        public void ItShouldGetWinningPlayer_None()
        {
            var state = new State();
            var player = state.GetWinningPlayer();

            Assert.Equal(Seat.NONE, player);
        }

        [Fact]
        public void ItShouldGetWinningPlayer_Horizontal()
        {
            AssertPlayerWins(Seat.ONE, "XXXEEEEEE");
            AssertPlayerWins(Seat.TWO, "OOOEEEEEE");

            AssertPlayerWins(Seat.ONE, "EEEXXXEEE");
            AssertPlayerWins(Seat.TWO, "EEEOOOEEE");

            AssertPlayerWins(Seat.ONE, "EEEEEEXXX");
            AssertPlayerWins(Seat.TWO, "EEEEEEOOO");
        }

        [Fact]
        public void ItShouldGetWinningPlayer_Vertical()
        {
            AssertPlayerWins(Seat.ONE, "XEEXEEXEE");
            AssertPlayerWins(Seat.TWO, "OEEOEEOEE");

            AssertPlayerWins(Seat.ONE, "EXEEXEEXE");
            AssertPlayerWins(Seat.TWO, "EOEEOEEOE");

            AssertPlayerWins(Seat.ONE, "EEXEEXEEX");
            AssertPlayerWins(Seat.TWO, "EEOEEOEEO");
        }

        [Fact]
        public void ItShouldGetWinningPlayer_Cross()
        {
            AssertPlayerWins(Seat.ONE, "XEEEXEEEX");
            AssertPlayerWins(Seat.TWO, "OEEEOEEEO");

            AssertPlayerWins(Seat.ONE, "EEXEXEXEE");
            AssertPlayerWins(Seat.TWO, "EEOEOEOEE");
        }

        private void AssertPlayerWins(Seat player, string board)
        {
            var state = new State();
            state.Set(board);

            Assert.Equal(player, state.GetWinningPlayer());
        }

        private string CreateString(int length)
        {
            var chars = new char[length];
            for (int i = 0; i < length; i++) { chars[i] = allowedChars[_random.Next(0, allowedChars.Length)]; }
            return new string(chars);
        }
    }
}
