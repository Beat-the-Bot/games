using System;

namespace Jarrus.Games.Exceptions
{
    [Serializable]
    public class InvalidTableException : Exception
    {
        public InvalidTableException(string message) : base(message) { }
    }
}
