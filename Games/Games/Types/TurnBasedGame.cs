using Jarrus.Event;
using Jarrus.Games.Event;

namespace Jarrus.Games.Types
{
    public abstract class TurnBasedGame : GameMechanics
    {
        public TurnBasedGame(byte numberOfPlayers) : base(numberOfPlayers) { }

        private byte _playerTurnIndex;

        protected override void Play() {

            while (!IsComplete())
            {
                var player = Players[_playerTurnIndex];

                Invoke(new EventPayload(EventType.PLAYER_TURN_START, player));

                _playerTurnIndex++;
                if (_playerTurnIndex == Players.Length) { _playerTurnIndex = 0; }
            }
        }

        public void OnPlayerActionTaken(EventAction move)
        {
            Process(move);
        }
    }
}
