using Jarrus.Event;
using Jarrus.Games;
using Jarrus.Games.Enums;
using Jarrus.Games.Players;
using Jarrus.Games.Utilities;
using Jarrus.TTT.Enums;

namespace Jarrus.TTT.CPU
{
    public class HardCPU : Agent
    {
        protected override EventAction DetermineMove(GameState gameState)
        {
            var state = (State)gameState;

            var winningMove = GetWinningMove(state);
            if (winningMove != -1) { return new Action(Seat, new int[1] { winningMove }); }

            var blockingMove = GetBlockingMove(state);
            if (blockingMove != -1) { return new Action(Seat, new int[1] { blockingMove }); }

            var randomSquare = GetRandomSquare(state);
            return new Action(Seat, new int[1] { randomSquare });
        }

        private int GetRandomSquare(State state)
        {
            while (true)
            {
                var number = GetRandomNumber(0, 8);
                if (state.Data[number] == Symbol.E)
                {
                    return number;
                }
            }
        }

        private int GetWinningMove(State state)
        {
            var emptyPositions = state.ToString().AllIndexesOf("E");

            foreach(byte position in emptyPositions)
            {
                if (WouldMoveWinGame(state, position))
                {
                    return position;
                }
            }

            return -1;
        }

        private int GetBlockingMove(State state)
        {
            var emptyPositions = state.ToString().AllIndexesOf("E");

            foreach (byte position in emptyPositions)
            {
                if (WouldMoveLoseGame(state, position))
                {
                    return position;
                }
            }

            return -1;
        }

        private bool WouldMoveWinGame(State state, byte position)
        {
            var duplicate = state.Duplicate();
            duplicate.Set(position, ConvertSeatToSymbol(Seat));

            var winner = duplicate.GetWinningPlayer();
            return winner == Seat;
        }

        private bool WouldMoveLoseGame(State state, byte position)
        {
            var mySymbol = ConvertSeatToSymbol(Seat);
            var oppositionSymbol = mySymbol == Symbol.X ? Symbol.O : Symbol.X;

            var duplicate = state.Duplicate();
            duplicate.Set(position, oppositionSymbol);

            var winner = duplicate.GetWinningPlayer();
            return winner != Seat.NONE && winner != Seat;
        }

        private Symbol ConvertSeatToSymbol(Seat seat)
        {
            return seat == Seat.ONE ? Symbol.X : Symbol.O;
        }
    }
}
