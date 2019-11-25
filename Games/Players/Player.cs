using Jarrus.Event;
using Jarrus.Games.Enums;
using Jarrus.Games.Event;
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

        public void TakeTurn(Seat seat)
        {
            if (seat != Seat) { return; }
            
            StartTurn();
            var move = DetermineMove(_game.State.GetStateFor(seat));
            _game.Process(move);
        }

        public void Sit() {
            if (_game == null) { throw new InvalidTableException("Unable to sit before joining a game."); }
            Seat = _game.OnPlayerSitDown(this);
        }

        public void Join(GameMechanics game)
        {
            _game = game;
            Seat = _game.OnPlayerJoin(this);
            Subscribe();
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
            Unsubscribe();
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

        protected void HandleEvent(EventPayload payload)
        {
            if (payload.Type == EventType.PLAYER_TURN_START) { TakeTurn(payload.Player.Seat); return; }
        }

        protected void Subscribe() { _game.EventStream += HandleEvent; }
        protected void Unsubscribe() { _game.EventStream -= HandleEvent; }
        public bool IsSittingDown() { return Seat.NONE != Seat && Seat.SPECTATOR != Seat; }
    }
}
