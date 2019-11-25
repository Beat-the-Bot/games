namespace Jarrus.Games.Cards
{
    public class Suit
    {
        public int Value { get; private set; }
        public string Name { get; private set; }

        private Suit(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public static Suit SPADE = new Suit(1, "Spade");
        public static Suit HEART = new Suit(2, "Heart");
        public static Suit CLUB = new Suit(3, "Club");
        public static Suit DIAMOND = new Suit(4, "Diamond");
    }
}
