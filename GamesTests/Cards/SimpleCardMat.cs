﻿using Jarrus.Games;
using Jarrus.Games.Cards;
using Jarrus.Games.Enums;

namespace Jarrus.GamesTests.Cards
{
    public class SimpleCardMat : StandardCardMatState
    {
        public SimpleCardMat() : base(4)
        {
        }

        public void ShuffleUp() { Shuffle(); }
        public int GetCardIndex() { return CardIndex;  }
        public PlayerHand[] GetHands() { return Hands; }
        public void DealOut(int numberOfCardsToEachPlayer) { Deal(numberOfCardsToEachPlayer); }
        public override GameState GetStateFor(Seat position) { return null; }
        public override Seat GetWinningPlayer() { return Seat.NONE; }
    }
}
