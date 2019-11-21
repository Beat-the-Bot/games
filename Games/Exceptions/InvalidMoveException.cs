using System;

namespace Jarrus.Games.Exceptions
{
    [Serializable]
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message) { }
    }
}
