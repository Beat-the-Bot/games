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
            for (byte i = 0; i < 2; i++)
            {
                var move = new Move(i, 0);
                Assert.Equal(Validation.VALID, move.GetValidation(State));
            }
        }

        [Fact]
        public void ItShouldDetermineIfMoveIsValid_Positions()
        {
            for (byte i = 0; i < 9; i++)
            {
                var move = new Move(0, i);
                Assert.Equal(Validation.VALID, move.GetValidation(State));
            }
        }

        [Fact]
        public void ItShouldDetermineMoveIsInvalid_InvalidPlayerId()
        {
            for(byte i = 2; i < byte.MaxValue; i++)
            {
                var move = new Move(i, 0);
                Assert.Equal(Validation.INVALID_PLAYERID, move.GetValidation(State));
            }
        }

        [Fact]
        public void ItShouldDetermineMoveIsInvalid_InvalidPosition()
        {
            for (byte i = 9; i < byte.MaxValue; i++)
            {
                var move = new Move(0, i);
                Assert.Equal(Validation.INVALID_POSITION, move.GetValidation(State));
            }
        }

        [Fact]
        public void ItShouldDetermineMoveIsInvalid_PositionTaken()
        {
            for (byte i = 0; i < 9; i++)
            {
                var move = new Move(0, i);
                Assert.Equal(Validation.VALID, move.GetValidation(State));

                State.Set(i, Symbol.X);
                Assert.Equal(Validation.INVALID_POSITION_TAKEN, move.GetValidation(State));
            }
        }
    }
}
