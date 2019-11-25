namespace Jarrus.Games.Cards
{
    public class StandardDeck : Deck
    {
        public StandardDeck() : base(52)
        {
            AddSuit(Suit.SPADE);
            AddSuit(Suit.HEART);
            AddSuit(Suit.CLUB);
            AddSuit(Suit.DIAMOND);
        }

        private void AddSuit(Suit suit)
        {
            AddCard(new PlayingCard(suit, 1, Card.ACE));
            AddCard(new PlayingCard(suit, 2, Card.TWO));
            AddCard(new PlayingCard(suit, 3, Card.THREE));
            AddCard(new PlayingCard(suit, 4, Card.FOUR));
            AddCard(new PlayingCard(suit, 5, Card.FIVE));
            AddCard(new PlayingCard(suit, 6, Card.SIX));
            AddCard(new PlayingCard(suit, 7, Card.SEVEN));
            AddCard(new PlayingCard(suit, 8, Card.EIGHT));
            AddCard(new PlayingCard(suit, 9, Card.NINE));
            AddCard(new PlayingCard(suit, 10, Card.TEN));
            AddCard(new PlayingCard(suit, 11, Card.JACK));
            AddCard(new PlayingCard(suit, 12, Card.QUEEN));
            AddCard(new PlayingCard(suit, 13, Card.KING));
        }
    }
}
