namespace Jarrus.Games.Cards
{
    public class Card
    {
        public string ShortName { get; private set; }
        public string FullName { get; private set; }

        private Card(string shortName, string fullName)
        {
            ShortName = shortName;
            FullName = fullName;
        }

        public static Card ACE = new Card("A", "Ace");
        public static Card TWO = new Card("2", "Two");
        public static Card THREE = new Card("3", "Three");
        public static Card FOUR = new Card("4", "Four");
        public static Card FIVE = new Card("5", "Five");
        public static Card SIX = new Card("6", "Six");
        public static Card SEVEN = new Card("7", "Seven");
        public static Card EIGHT = new Card("8", "Eight");
        public static Card NINE = new Card("9", "Nine");
        public static Card TEN = new Card("10", "Ten");
        public static Card JACK = new Card("J", "Jack");
        public static Card QUEEN = new Card("Q", "Queen");
        public static Card KING = new Card("K", "King");
        public static Card JOKER = new Card("O", "Joker");
    }
}
