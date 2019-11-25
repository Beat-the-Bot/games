using Jarrus.Event;
using Jarrus.Games;
using Jarrus.Games.Enums;
using Jarrus.TTT.Enums;

namespace Jarrus.TTT
{
    public class Action : EventAction
    {
        public byte Position;

        public Action(Seat player, int[] instructions) : base(player, instructions) {
            Player = player;
            Position = (byte)instructions[0];
        }

        public Action(Seat player, byte position) : base(player, new int[1] { position })
        {
            Player = player;
            Position = position;
        }

        public Validation GetValidationType(GameState state)
        {
            var tttState = (State)state;

            var isPlayerIdValid = Player == Seat.ONE || Player == Seat.TWO;
            if (!isPlayerIdValid) { return Validation.INVALID_PLAYERID; }

            var isPositionValid = 0 <= Position && Position <= 8;
            if (!isPositionValid) { return Validation.INVALID_POSITION; }

            var isPositionEmpty = tttState.Data[Position] == Symbol.E;
            if (!isPositionEmpty) { return Validation.INVALID_POSITION_TAKEN; }

            return Validation.VALID;
        }

        public Symbol GetSymbol() { return Player == Seat.ONE ? Symbol.X : Symbol.O; }
    }
}
