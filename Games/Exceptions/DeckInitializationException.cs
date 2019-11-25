using System;

namespace Jarrus.Games.Exceptions
{
    [Serializable]
    public class DeckInitializationException : Exception
    {
        public DeckInitializationException(string message) : base(message) { }
    }
}
