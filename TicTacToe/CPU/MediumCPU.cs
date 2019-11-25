using Jarrus.Event;
using Jarrus.Games;
using Jarrus.Games.Players;
using Jarrus.TTT.Enums;

namespace Jarrus.TTT.CPU
{
    public class MediumCPU : Agent
    {
        protected override EventAction DetermineMove(GameState gameState)
        {
            var state = (State)gameState;

            var randomSquare = GetRandomSquare(state);
            return new Action(Seat, new int[1] { randomSquare });
        }

        private int GetRandomSquare(State state)
        {
            while(true)
            {
                var number = GetRandomNumber(0, 8);
                if (state.Data[number] == Symbol.E)
                {
                    return number;
                }
            }
        }
    }
}
