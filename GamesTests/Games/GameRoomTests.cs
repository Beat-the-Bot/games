using Jarrus.Games.Enums;
using Jarrus.Games.Event;
using Jarrus.Games.Exceptions;
using Jarrus.TTT;
using Jarrus.TTT.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Jarrus.GamesTests
{
    public class GameRoomTests : IDisposable
    {
        public TicTacToeGame Game;
        public List<EasyAgent> Players = new List<EasyAgent>();
        public List<EventPayload> Events = new List<EventPayload>();

        public GameRoomTests()
        {
            Game = new TicTacToeGame();
            Game.EventStream += OnEvent;

            Players.Add(new EasyAgent());
            Players.Add(new EasyAgent());
            Players.Add(new EasyAgent());
        }

        [Fact]
        public void ItShouldShowAMeaningfulBoardAsAString()
        {
            var game = new TicTacToeGame();
            Assert.Equal("EEEEEEEEE", game.ToString());
        }

        [Fact]
        public void ItShouldAllowPlayersToJoinAGame()
        {
            Players[0].Join(Game);
            AssertEventOccured(EventType.PLAYER_JOINED_TABLE, 1);
            AssertEventOccured(EventType.SPECTATOR_LIST_CHANGED, 1);
            
            Assert.Equal(Seat.SPECTATOR, Players[0].Seat);
            Assert.Equal(1, Game.GetNumberOfSpectators());
        }

        [Fact]
        public void ItShouldAllowAPlayerToSitDown()
        {
            Players[0].Join(Game);
            Players[0].Sit();

            AssertEventOccured(EventType.SPECTATOR_LIST_CHANGED, 2);
            AssertEventOccured(EventType.PLAYER_SAT_DOWN, 1);
            Assert.Equal(Seat.ONE, Players[0].Seat);
        }

        [Fact]
        public void ItShouldAllowAPlayerToStandUp()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Stand();

            AssertEventOccured(EventType.SPECTATOR_LIST_CHANGED, 3);
            AssertEventOccured(EventType.PLAYER_SAT_DOWN, 1);
            AssertEventOccured(EventType.PLAYER_STOOD_UP, 1);
            Assert.Equal(Seat.SPECTATOR, Players[0].Seat);
        }

        [Fact]
        public void ItShouldNotAllowAPlayerToSitDownIfAlreadySitting()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Sit();

            AssertEventOccured(EventType.SPECTATOR_LIST_CHANGED, 2);
            AssertEventOccured(EventType.PLAYER_SAT_DOWN, 1);
            AssertEventOccured(EventType.PLAYER_CANNOT_SIT, 1);
            Assert.Equal(Seat.ONE, Players[0].Seat);
        }

        [Fact]
        public void ItShouldNotAllowAPlayerToSitIfNoSpacesAvailable()
        {
            Players[0].Join(Game);
            Players[0].Sit();

            Players[1].Join(Game);
            Players[1].Sit();

            Players[2].Join(Game);
            Players[2].Sit();

            AssertEventOccured(EventType.SPECTATOR_LIST_CHANGED, 5);
            AssertEventOccured(EventType.PLAYER_SAT_DOWN, 2);
            AssertEventOccured(EventType.PLAYER_CANNOT_SIT, 1);
            Assert.Equal(Seat.ONE, Players[0].Seat);
            Assert.Equal(Seat.TWO, Players[1].Seat);
            Assert.Equal(Seat.SPECTATOR, Players[2].Seat);
        }

        [Fact]
        public void ItShouldGetNumberOfPlayers()
        {
            Assert.Equal(0, Game.GetNumberOfSpectators());
            Assert.Equal(0, Game.GetNumberOfSittingPlayers());
            Assert.Equal(0, Game.GetNumberOfPlayers());

            Players[0].Join(Game);
            Assert.Equal(1, Game.GetNumberOfSpectators());
            Assert.Equal(0, Game.GetNumberOfSittingPlayers());
            Assert.Equal(1, Game.GetNumberOfPlayers());

            Players[0].Sit();
            Assert.Equal(0, Game.GetNumberOfSpectators());
            Assert.Equal(1, Game.GetNumberOfSittingPlayers());
            Assert.Equal(1, Game.GetNumberOfPlayers());

            Players[1].Join(Game);
            Assert.Equal(1, Game.GetNumberOfSpectators());
            Assert.Equal(1, Game.GetNumberOfSittingPlayers());
            Assert.Equal(2, Game.GetNumberOfPlayers());

            Players[1].Sit();
            Assert.Equal(0, Game.GetNumberOfSpectators());
            Assert.Equal(2, Game.GetNumberOfSittingPlayers());
            Assert.Equal(2, Game.GetNumberOfPlayers());

            Players[2].Join(Game);
            Assert.Equal(1, Game.GetNumberOfSpectators());
            Assert.Equal(2, Game.GetNumberOfSittingPlayers());
            Assert.Equal(3, Game.GetNumberOfPlayers());

            Players[2].Sit();
            Assert.Equal(1, Game.GetNumberOfSpectators());
            Assert.Equal(2, Game.GetNumberOfSittingPlayers());
            Assert.Equal(3, Game.GetNumberOfPlayers());
        }

        [Fact]
        public void ItShouldGetNumberOfSeatsOpen()
        {
            Assert.Equal(2, Game.GetNumberOfSeatsOpen());

            Players[0].Join(Game);
            Players[0].Sit();
            Assert.Equal(1, Game.GetNumberOfSeatsOpen());

            Players[1].Join(Game);
            Players[1].Sit();
            Assert.Equal(0, Game.GetNumberOfSeatsOpen());

            Players[2].Join(Game);
            Players[2].Sit();
            Assert.Equal(0, Game.GetNumberOfSeatsOpen());
        }

        [Fact]
        public void ItShouldReadyPlayer()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();

            Assert.True(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_READY, 1);
        }

        [Fact]
        public void ItShouldNotRepeatReadyPlayer()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Players[0].Ready();
            Players[0].Ready();

            Assert.True(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_READY, 1);
        }

        [Fact]
        public void ItShouldNotReadyPlayer()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Players[0].NotReady();

            Assert.False(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_NOT_READY, 1);
        }

        [Fact]
        public void ItShouldNotRepeatNotReadyPlayer()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Players[0].NotReady();
            Players[0].NotReady();

            Assert.False(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_NOT_READY, 1);
        }

        [Fact]
        public void ItShouldStandPlayerUp()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Players[0].Stand();

            Assert.False(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_NOT_READY, 1);
            AssertEventOccured(EventType.PLAYER_STOOD_UP, 1);
            Assert.Equal(Seat.SPECTATOR, Players[0].Seat);
        }

        [Fact]
        public void ItShouldNotRepeatedlyStand()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Players[0].Stand();
            Players[0].Stand();

            Assert.False(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_NOT_READY, 1);
            AssertEventOccured(EventType.PLAYER_STOOD_UP, 1);
            Assert.Equal(Seat.SPECTATOR, Players[0].Seat);
        }

        [Fact]
        public void ItShouldLetPlayerLeave_FromSittingAndReady()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Players[0].Leave();

            Assert.False(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_NOT_READY, 1);
            AssertEventOccured(EventType.PLAYER_LEFT_TABLE, 1);
            Assert.Equal(Seat.NONE, Players[0].Seat);
        }

        [Fact]
        public void ItShouldFailIfActionBeforeJoining()
        {
            Assert.Throws<InvalidTableException>(() => Players[0].Sit());
            Assert.Throws<InvalidTableException>(() => Players[0].Stand());
            Assert.Throws<InvalidTableException>(() => Players[0].Ready());
            Assert.Throws<InvalidTableException>(() => Players[0].NotReady());
        }

        [Fact]
        public void ItShouldGetNumberOfPlayersReady()
        {
            Assert.Equal(0, Game.GetNumberOfPlayersReady());

            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();
            Assert.Equal(1, Game.GetNumberOfPlayersReady());

            Players[1].Join(Game);
            Players[1].Sit();
            Players[1].Ready();
            Assert.Equal(2, Game.GetNumberOfPlayersReady());

            Players[2].Join(Game);
            Players[2].Sit();
            Players[2].Ready();
            Assert.Equal(2, Game.GetNumberOfPlayersReady());
        }

        [Fact]
        public void ItShouldIgnoreReadyIfPlayerIsNotSitting()
        {
            Players[0].Join(Game);
            Players[0].Ready();

            Assert.False(Players[0].IsReady);
            AssertEventOccured(EventType.PLAYER_READY, 0);
        }

        [Fact]
        public void ItShouldDetermineIfReadyToBegin()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();

            Assert.False(Game.IsReadyToBegin());

            Players[1].Join(Game);
            Players[1].Sit();
            Assert.False(Game.IsReadyToBegin());

            Players[1].Ready();
            Assert.True(Game.IsReadyToBegin());
        }

        [Fact]
        public void ItShouldBeginGameIfAllPlayersReady()
        {
            Players[0].Join(Game);
            Players[0].Sit();
            Players[0].Ready();

            Players[1].Join(Game);
            Players[1].Sit();
            Players[1].Ready();

            AssertEventOccured(EventType.GAME_WILL_START, 1);
            AssertEventOccured(EventType.GAME_STARTED, 0);
        }

        void AssertEventOccured(EventType type, int times = -1) {
            var occurrences = Events.Where(o => o.Type == type).Count();
            var countIsCorrect = (occurrences > 0 && times == -1) || (times != -1 && times == occurrences);
            Assert.True(countIsCorrect);
        }

        private void OnEvent(EventPayload payload) { Events.Add(payload); }
        public void Dispose() { }
    }
}
