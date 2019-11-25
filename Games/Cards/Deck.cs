using Jarrus.Games.Utilities;
using System;
using System.Linq;

namespace Jarrus.Games.Cards
{
    public abstract class Deck
    {
        protected PlayingCard[] Cards;
        private int _position;
        private int _seed;
        protected Random Random;

        public Deck(int numberOfCards) { 
            Cards = new PlayingCard[numberOfCards];

            var random = new Random();
            SetSeed(random.Next(1, int.MaxValue));
        }

        public void SetSeed(int seed)
        {
            _seed = seed;
            Random = new Random(_seed);
        }

        public void Cut(int place)
        {
            if (place < 0 || place >= Cards.Length) { return; }

            var firstHalf = Cards.Take(place);
            var secondHalf = Cards.Skip(place).Take(Cards.Length - place);

            Cards = secondHalf.Concat(firstHalf).ToArray();
        }

        public void Shuffle() { Random.Shuffle(Cards); }
        public PlayingCard GetRandomCard() { return Cards[Random.Next(0, Cards.Length)]; }
        public int GetSeed() { return _seed; }
        public int Count() { return Cards.Length; }
        public PlayingCard[] GetCards() { return Cards; }
        public PlayingCard Get(int index = 0) { return Cards[index]; }
        protected void AddCard(PlayingCard card) { Cards[_position++] = card; }
    }
}
