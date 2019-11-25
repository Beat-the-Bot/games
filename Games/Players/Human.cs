using Jarrus.Event;

namespace Jarrus.Games.Players
{
    public class Human : Player
    {
        protected override EventAction DetermineMove(GameState gameState)
        {
            var input = 0; //prompt the user and get their input
            return new EventAction(Seat, new int[1] { input });
        }
    }
}
