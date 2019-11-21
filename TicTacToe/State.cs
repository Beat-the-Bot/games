using Jarrus.Games;
using Jarrus.TTT.Enums;
using System.Text;

namespace Jarrus.TTT
{
    public class State : GameState
    {
        private const byte SIZE = 9;
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

        public void Set(byte position, Symbol symbol)
        {
            Data[position] = symbol;
        }
    }
}
