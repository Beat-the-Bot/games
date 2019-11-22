using Jarrus.Games.Enums;

namespace Jarrus.Event
{
    public class EventAction
    {
        public Seat Player;
        public int[] Instructions;

        public EventAction(Seat player, int[] instructions)
        {
            Player = player;
            Instructions = instructions;
        }
    }
}
