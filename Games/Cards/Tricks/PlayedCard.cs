using Jarrus.Games.Enums;

namespace Jarrus.Games.Cards.Tricks
{
    public class PlayedCard
    {
        public Seat Seat { get; private set; }
        public PlayingCard Card { get; private set; }
        
        public PlayedCard(Seat seat, PlayingCard card)
        {
            Seat = seat;
            Card = card;            
        }
    }
}
