using Jarrus.Games;
using Jarrus.Games.Exceptions;
using Jarrus.TTT.Enums;

namespace Jarrus.TTT
{
    public class Board : GameBoard
    {
        private State _state;

        public Board()
        {
            _state = new State();
        }

        public void Process(Move move)
        {
            var validation = move.GetValidation(_state);
            if (validation != Validation.VALID) { throw new InvalidMoveException(validation.ToString()); }
            _state.Set(move.Position, move.GetSymbol());
        }

        public override string ToString() { return _state.ToString(); }
    }
}
