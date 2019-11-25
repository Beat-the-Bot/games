using Jarrus.Games.Cards;

namespace Jarrus.GamesTests.Cards
{
    public class CardTestHelper
    {
        public static int GetNumberOfCards(Deck deck, Card card)
        {
            var count = 0;

            foreach (var pcard in deck.GetCards())
            {
                if (pcard.Card == card) { count++; }
            }

            return count;
        }

        public static int GetNumberOfCards(Deck deck, Suit suit)
        {
            var count = 0;

            foreach (var pcard in deck.GetCards())
            {
                if (pcard.Suit == suit) { count++; }
            }

            return count;
        }
    }
}
