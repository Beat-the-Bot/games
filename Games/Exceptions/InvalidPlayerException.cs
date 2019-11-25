using System;

namespace Jarrus.Games.Exceptions
{
    [Serializable]
    public class InvalidPlayerException : Exception
    {
        public InvalidPlayerException(string message) : base(message) { }
    }
}
