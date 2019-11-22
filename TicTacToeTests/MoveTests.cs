using Jarrus.Games.Enums;
using Jarrus.TTT;
using Jarrus.TTT.Enums;
using System;
using Xunit;

namespace Jarrus.TTTTests
{
    public class MoveTests : IDisposable
    {
        public State State;

        public MoveTests() { State = new State(); }
        public void Dispose() { State = null; }

        [Fact]
        public void ItShouldDetermineIfMoveIsValid_PlayerIds()
        {
            for (byte i = 1; i < 3; i++)
            {
                var move = new TTT.Action((Seat)i, 0);
                Assert.Equal(Validation.VALID, move.GetValidationType(State));
            }
        }

        [Fact]
        public void ItShouldDetermineIfMoveIsValid_Positions()
        {
            for (byte i = 0; i < 9; i++)
            {
                var move = new TTT.Action(Seat.ONE, i);
                Assert.Equal(Validation.VALID, move.GetValidationType(State));
            }
        }

        [Fact]
        public void ItShouldDetermineMoveIsInvalid_InvalidPlayerId()
        {
            var noPlayerMove = new TTT.Action(Seat.NONE, 0);
            Assert.Equal(Validation.INVALID_PLAYERID, noPlayerMove.GetValidationType(State));

            for (byte i = 3; i < byte.MaxValue; i++)
            {
                var move = new TTT.Action((Seat)i, 0);
                Assert.Equal(Validation.INVALID_PLAYERID, move.GetValidationType(State));
            }
        }

        [Fact]
        public void ItShouldDetermineMoveIsInvalid_InvalidPosition()
        {
            for (byte i = 9; i < byte.MaxValue; i++)
            {
                var move = new TTT.Action(Seat.ONE, i);
                Assert.Equal(Validation.INVALID_POSITION, move.GetValidationType(State));
            }
        }

        [Fact]
        public void ItShouldDetermineMoveIsInvalid_PositionTaken()
        {
            for (byte i = 0; i < 9; i++)
            {
                var move = new TTT.Action(Seat.ONE, i);
                Assert.Equal(Validation.VALID, move.GetValidationType(State));

                State.Set(i, Symbol.X);
                Assert.Equal(Validation.INVALID_POSITION_TAKEN, move.GetValidationType(State));
            }
        }
    }
}
