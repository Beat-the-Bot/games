using Jarrus.Games;
using Jarrus.Games.Enums;
using Jarrus.TTT.Enums;
using System;
using System.Linq;
using System.Text;

namespace Jarrus.TTT
{
    public class State : GameState
    {
        public const byte SIZE = 9;
        public Symbol[] Data;

        public State()
        {
            Data = new Symbol[SIZE];

            for (var i = 0; i < SIZE; i++)
            {
                Data[i] = Symbol.E;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < SIZE; i++)
            {
                sb.Append(Data[i]);
            }

            return sb.ToString();
        }

        public void Set(string str)
        {
            if (str.Length != SIZE) { throw new ArgumentException("String is of the wrong length"); }

            for(var i = 0; i < SIZE; i++)
            {
                if (str[i] == 'X') { Data[i] = Symbol.X; continue; }
                if (str[i] == 'O') { Data[i] = Symbol.O; continue; }
                Data[i] = Symbol.E;
            }
        }

        public override Seat GetWinningPlayer()
        {
            //horizontal win
            if (IsWinConditionMet(0, 1, 2)) { return ConvertSymbolToPlayer(Data[0]); }
            if (IsWinConditionMet(3, 4, 5)) { return ConvertSymbolToPlayer(Data[3]); }
            if (IsWinConditionMet(6, 7, 8)) { return ConvertSymbolToPlayer(Data[6]); }

            //vertical win
            if (IsWinConditionMet(0, 3, 6)) { return ConvertSymbolToPlayer(Data[0]); }
            if (IsWinConditionMet(1, 4, 7)) { return ConvertSymbolToPlayer(Data[1]); }
            if (IsWinConditionMet(2, 5, 8)) { return ConvertSymbolToPlayer(Data[2]); }

            //cross win
            if (IsWinConditionMet(0, 4, 8)) { return ConvertSymbolToPlayer(Data[0]); }
            if (IsWinConditionMet(2, 4, 6)) { return ConvertSymbolToPlayer(Data[2]); }

            return Seat.NONE;
        }

        protected bool IsWinConditionMet(int placeOne, int placeTwo, int placeThree) { 
            return Symbol.E != Data[placeOne] && Data[placeOne] == Data[placeTwo] && Data[placeTwo] == Data[placeThree];
        }

        private Seat ConvertSymbolToPlayer(Symbol symbol)
        {
            if (symbol == Symbol.E) { return Seat.NONE; }
            return symbol == Symbol.X ? Seat.ONE : Seat.TWO;
        }

        public void Set(byte position, Symbol symbol)
        {
            Data[position] = symbol;
        }

        public int GetEmptySpaces() { return Data.Where(o => o == Symbol.E).Count(); }

        public override GameState GetStateFor(Seat position) { return this; }
    }
}
