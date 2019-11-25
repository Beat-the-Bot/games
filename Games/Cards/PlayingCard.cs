namespace Jarrus.Games.Cards
{
    public class PlayingCard
    {
        public Suit Suit;
        public Card Card;
        public int Value;

        public PlayingCard(Suit suit, int value, Card card)
        {
            Suit = suit;
            Card = card;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var card = (PlayingCard)obj;
            return card.Suit == Suit && card.Card == Card;
        }

        public override string ToString() { return string.Format("{0} of {1}s", Card.FullName, Suit.Name); }
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
