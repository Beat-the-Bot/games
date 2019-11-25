using Jarrus.Games.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Jarrus.Games.Cards.Tricks
{
    public abstract class TrickBasedState : GameState
    {
        protected StandardDeck Deck = new StandardDeck();
        protected int CardIndex = 0;
        protected PlayerHand[] Hands;
        protected List<PlayedCard> Board;
        protected List<Trick> Tricks = new List<Trick>();

        public TrickBasedState(int numberOfPlayers)
        {
            InitializePlayerHands(numberOfPlayers);
            Board = new List<PlayedCard>();
        }

        private void InitializePlayerHands(int numberOfPlayers)
        {
            Hands = new PlayerHand[numberOfPlayers];
            for (var i = 1; i < numberOfPlayers + 1; i++)
            {
                Hands[i - 1] = new PlayerHand((Seat)i);
            }
        }

        public void Play(Seat seat, PlayingCard card)
        {
            var hand = Hands.Where(o => o.Seat == seat).First();
            hand.Cards.Remove(card);
            Board.Add(new PlayedCard(seat, card));

            if (Board.Count() == Hands.Length)
            {
                GivePlayerTrick(DetermineWhoWinsTrick());
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
            Tricks = new List<Trick>();

            Deck.Shuffle();
        }

        protected void GivePlayerTrick(Seat seat)
        {
            Tricks.Add(new Trick(seat, Board.ToArray()));
            Board = new List<PlayedCard>();
        }

        protected abstract Seat DetermineWhoWinsTrick();

        public void SetSeed(int seed) { Deck.SetSeed(seed); }
        public override string ToString() { return JsonConvert.SerializeObject(this); }
    }
}
