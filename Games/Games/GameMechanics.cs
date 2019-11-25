using Jarrus.Event;
using Jarrus.Games.Event;

namespace Jarrus.Games
{
    public abstract class GameMechanics : GameRoom
    {
        public GameMechanics(byte numberOfPlayers) : base(numberOfPlayers)
        {
        }

        public abstract void Process(EventAction action);
        public abstract bool IsComplete();
        protected abstract void ProcessMove(EventAction gameMove);
        protected abstract bool IsValidMove(EventAction gameMove);
        public abstract override string ToString();
    }
}
