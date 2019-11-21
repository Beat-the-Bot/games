using Jarrus.TTT.Enums;

namespace Jarrus.TTT
{
    public class Move
    {
        public byte PlayerId;
        public byte Position;

        public Move(byte playerId, byte position)
        {
            PlayerId = playerId;
            Position = position;
        }

        public Validation GetValidation(State state)
        {
            var isPlayerIdValid = PlayerId == 0 || PlayerId == 1;
            if (!isPlayerIdValid) { return Validation.INVALID_PLAYERID; }

            var isPositionValid = 0 <= Position && Position <= 8;
            if (!isPositionValid) { return Validation.INVALID_POSITION; }

            var isPositionEmpty = state.Data[Position] == Symbol.E;
            if (!isPositionEmpty) { return Validation.INVALID_POSITION_TAKEN; }

            return Validation.VALID;
        }

        public Symbol GetSymbol() { return PlayerId == 0 ? Symbol.X : Symbol.Y; }
    }
}
