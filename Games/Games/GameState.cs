using Jarrus.Games.Enums;

namespace Jarrus.Games
{
    public abstract class GameState
    {
        public abstract override string ToString();
        public abstract Seat GetWinningPlayer();
        public abstract GameState GetStateFor(Seat position);
    }
}
