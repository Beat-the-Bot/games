using Jarrus.Event;

namespace Jarrus.Games
{
    public abstract class TurnBasedGame : GameMechanics
    {
        public TurnBasedGame(byte numberOfPlayers) : base(numberOfPlayers) { }

        //private byte _playerTurnIndex;

        protected override void Play() {
            
            //while(!IsComplete())
            //{
            //    var position = Players[_playerTurnIndex].Seat;
            //    //StartPlayerTurn?.Invoke(this, position);

            //    _playerTurnIndex++;
            //    if (_playerTurnIndex == Players.Length) { _playerTurnIndex = 0; }
            //}
        }

        public void OnPlayerActionTaken(EventAction move)
        {
            Process(move);
        }
    }
}
