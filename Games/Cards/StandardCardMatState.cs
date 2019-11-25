using Jarrus.Games.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jarrus.Games.Cards
{
    public abstract class StandardCardMatState : GameState
    {
        protected StandardDeck Deck = new StandardDeck();
        protected int CardIndex = 0;
        protected PlayerHand[] Hands;
        
        public StandardCardMatState(int numberOfPlayers)
        {
            InitializePlayerHands(numberOfPlayers);
        }

        private void InitializePlayerHands(int numberOfPlayers)
        {
            Hands = new PlayerHand[numberOfPlayers];
            for (var i = 1; i < numberOfPlayers + 1; i++)
            {
                Hands[i - 1] = new PlayerHand((Seat)i);
            }
        }

        protected void Deal(int numberOfCardsToEachPlayer)
        {
            for(var i = 0; i < numberOfCardsToEachPlayer; i++)
            {
                for(var k = 0; k < Hands.Length; k++)
                {
                    Hands[k].Cards.Add(Deck.Get(CardIndex++));
                }
            }
        }

        protected void Shuffle()
        {
            CardIndex = 0;
            foreach (var hand in Hands) { hand.Cards = new List<PlayingCard>(); }
            Deck.Shuffle();
        }

        public void SetSeed(int seed) { Deck.SetSeed(seed); }
        public override string ToString() { return JsonConvert.SerializeObject(this); }
    }
}
