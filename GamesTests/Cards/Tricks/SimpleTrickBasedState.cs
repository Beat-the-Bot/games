using Jarrus.Games;
using Jarrus.Games.Cards;
using Jarrus.Games.Cards.Tricks;
using Jarrus.Games.Enums;
using System.Collections.Generic;

namespace Jarrus.GamesTests.Cards.Tricks
{
    public class SimpleTrickBasedState : TrickBasedState
    {
        public SimpleTrickBasedState() : base(4)
        {
        }

        public List<Trick> GetTricks() { return Tricks; }
        public List<PlayedCard> GetBoard() { return Board; }
        public void ShuffleUp() { Shuffle(); }
        public int GetCardIndex() { return CardIndex;  }
        public PlayerHand[] GetHands() { return Hands; }
        public void DealOut(int numberOfCardsToEachPlayer) { Deal(numberOfCardsToEachPlayer); }
        public override GameState GetStateFor(Seat position) { return null; }
        public override Seat GetWinningPlayer() { return Seat.NONE; }

        protected override Seat DetermineWhoWinsTrick() { return Seat.ONE; }
    }
}
