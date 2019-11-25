using Jarrus.Event;
using Jarrus.Games.Enums;
using Jarrus.Games.Event;
using Jarrus.Games.Players;
using System.Linq;

namespace Jarrus.Games.Types
{
    public abstract class TurnBasedGame : GameMechanics
    {
        public TurnBasedGame(byte numberOfPlayers) : base(numberOfPlayers) { }

        private byte _playerTurnIndex;

        protected override void Play() {

            var player = Players[_playerTurnIndex];
            Invoke(new EventPayload(EventType.PLAYER_TURN_START, player));
        }

        protected void AdvanceTurn()
        {
            var gameComplete = CompleteGame();
            if (gameComplete) { return; }

            _playerTurnIndex++;
            if (_playerTurnIndex == Players.Length) { _playerTurnIndex = 0; }

            var player = Players[_playerTurnIndex];
            Invoke(new EventPayload(EventType.PLAYER_TURN_START, player));
        }

        private bool CompleteGame()
        {
            var completedGame = IsComplete();

            if (completedGame)
            {
                var winningPlayerSeat = State.GetWinningPlayer();
                var winningPlayer = Players.Where(o => o.Seat == winningPlayerSeat).FirstOrDefault();
                
                Invoke(new EventPayload(EventType.GAME_COMPLETE));
                Invoke(new EventPayload(EventType.GAME_WINNER, winningPlayer));
                return true;
            }

            return false;
        }

        public override void Process(EventAction gameMove)
        {
            ProcessMove(gameMove);
            AdvanceTurn();
        }

        public void OnPlayerActionTaken(EventAction move)
        {
            Process(move);
        }
    }
}
