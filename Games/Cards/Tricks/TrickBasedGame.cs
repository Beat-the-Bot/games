using Jarrus.Event;
using Jarrus.Games.Types;

namespace Jarrus.Games.Cards.Tricks
{
    public class TrickBasedGame : TurnBasedGame
    {
        public TrickBasedGame(byte numberOfPlayers) : base(numberOfPlayers)
        {
        }

        public override bool IsComplete()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsValidMove(EventAction gameMove)
        {
            throw new System.NotImplementedException();
        }

        protected override void ProcessMove(EventAction gameMove)
        {
            throw new System.NotImplementedException();
        }
    }
}
