using Jarrus.Event;
using Jarrus.Games;
using Jarrus.Games.Players;
using Jarrus.TTT.Enums;

namespace Jarrus.TTT.CPU
{
    public class EasyAgent : Player
    {
        protected override void StartTurn()
        {
        }

        protected override EventAction DetermineMove(GameState gameState)
        {
            var state = (State)gameState;

            var firstOpenSquare = GetFirstOpenSquare(state);
            return new Action(Seat, firstOpenSquare);
        }

        private byte GetFirstOpenSquare(State state)
        {
            for(byte i = 0; i < state.Data.Length; i++)
            {
                if (state.Data[i] == Symbol.E)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
