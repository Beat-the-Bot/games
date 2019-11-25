using Jarrus.Games.Enums;
using System.Collections.Generic;

namespace Jarrus.Games.Cards
{
    public class PlayerHand
    {
        public Seat Seat;
        public List<PlayingCard> Cards = new List<PlayingCard>();

        public PlayerHand(Seat seat) { Seat = seat; }
    }
}
