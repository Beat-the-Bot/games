using Jarrus.Event;
using Jarrus.Games.Enums;
using Jarrus.Games.Exceptions;

namespace Jarrus.Games.Players
{
    public abstract class Player
    {
        public Seat Seat;
        public bool IsReady;
        private GameMechanics _game;

        protected abstract void StartTurn();
        protected abstract EventAction DetermineMove(GameState gameState);

        public void TakeTurn(GameMechanics game, Seat player)
        {
            if (player != Seat) { return; }
            
            StartTurn();
            var move = DetermineMove(game.State.GetStateFor(player));
            //MakeMove(move);
        }

        public void Sit() {
            if (_game == null) { throw new InvalidTableException("Unable to sit before joining a game."); }
            Seat = _game.OnPlayerSitDown(this);
        }

        public void Join(GameMechanics game)
        {
            _game = game;
            Seat = _game.OnPlayerJoin(this);
        }

        public void Stand()
        {
            if (_game == null) { throw new InvalidTableException("Unable to stand before joining a game."); }
            if (!IsSittingDown()) { return; }

            NotReady();
            Seat = _game.OnPlayerStandUp(this);
        }

        public void Leave()
        {
            if (Seat == Seat.NONE) { return; }
            Seat = _game.OnPlayerLeave(this);
            IsReady = false;
            _game = null;
        }

        public void Ready() {
            if (_game == null) { throw new InvalidTableException("Unable to ready before joining a game."); }
            if (!IsSittingDown()) { return; }

            if (IsReady) { return; }
            IsReady = true; _game.OnPlayerReady(this);
        }

        public void NotReady() {
            if (_game == null) { throw new InvalidTableException("Unable to not ready before joining a game."); }

            if (!IsReady) { return; }
            IsReady = false; _game.OnPlayerNotReady(this);
        }

        public bool IsSittingDown() { return Seat.NONE != Seat && Seat.SPECTATOR != Seat; }
    }
}
