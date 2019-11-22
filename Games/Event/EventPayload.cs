using Jarrus.Event;
using Jarrus.Games.Players;

namespace Jarrus.Games.Event
{
    public class EventPayload
    {
        public EventType Type;
        public Player Player;
        public EventAction Action;

        public EventPayload(EventType type, Player player = null, EventAction action = null)
        {
            Type = type;
            Player = player;
            Action = action;
        }
    }
}
