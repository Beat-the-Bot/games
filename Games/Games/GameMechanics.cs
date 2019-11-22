using Jarrus.Event;

namespace Jarrus.Games
{
    public abstract class GameMechanics : GameRoom
    {
        public GameMechanics(byte numberOfPlayers) : base(numberOfPlayers)
        {
        }

        public abstract bool IsComplete();
        public abstract void Process(EventAction gameMove);
        public abstract override string ToString();
    }
}
