using Jarrus.Games.Enums;

namespace Jarrus.Games.Cards.Tricks
{
    public class Trick
    {
        public Seat Seat { get; private set; }
        public PlayedCard[] Cards { get; private set; }

        public Trick(Seat seat, PlayedCard[] cards)
        {
            Seat = seat;
            Cards = cards;
        }
    }
}
