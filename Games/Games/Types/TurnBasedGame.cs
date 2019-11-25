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

        protected override void Play()
        {
            var player = Players[_playerTurnIndex];
            Invoke(new EventPayload(EventType.ROUND_START));
            Invoke(new EventPayload(EventType.PLAYER_TURN_START, player));
        }

        public override void Process(EventAction gameMove)
        {
            ProcessMove(gameMove);

            var currentPlayer = Players[_playerTurnIndex];
            Invoke(new EventPayload(EventType.PLAYER_ACTION_TAKEN, currentPlayer, gameMove));
            Invoke(new EventPayload(EventType.PLAYER_TURN_COMPLETE, currentPlayer));
            
            AdvanceTurn();
        }

        protected void AdvanceTurn()
        {
            var gameComplete = CompleteGame();
            if (gameComplete) { return; }

            _playerTurnIndex++;
            if (_playerTurnIndex == Players.Length) { 
                _playerTurnIndex = 0;
                Invoke(new EventPayload(EventType.ROUND_END));
                Invoke(new EventPayload(EventType.ROUND_START));
            }

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

        public void OnPlayerActionTaken(EventAction move)
        {
            Process(move);
        }
    }
}
