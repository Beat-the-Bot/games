using Jarrus.Games.Enums;
using Jarrus.Games.Event;
using Jarrus.Games.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jarrus.Games
{
    public abstract class GameRoom
    {
        public Player[] Players;
        public List<Player> Spectators;
        public GameState State;

        public event EventTypeDelegate EventStream;
        public delegate void EventTypeDelegate(EventPayload args);

        public GameRoom(byte numberOfPlayers)
        {
            Players = new Player[numberOfPlayers];
            Spectators = new List<Player>();
        }

        internal Seat OnPlayerJoin(Player player)
        {
            Spectators.Add(player);

            EventStream?.Invoke(new EventPayload(EventType.PLAYER_JOINED_TABLE, player));
            EventStream?.Invoke(new EventPayload(EventType.SPECTATOR_LIST_CHANGED));

            return Seat.SPECTATOR;
        }

        internal Seat OnPlayerSitDown(Player player)
        {
            var seatNumber = GetFirstOpenSeat();
            if (player.IsSittingDown() || seatNumber == -1) { EventStream?.Invoke(new EventPayload(EventType.PLAYER_CANNOT_SIT, player)); return player.Seat; }

            Players[seatNumber] = player;

            Spectators.Remove(player);
            EventStream?.Invoke(new EventPayload(EventType.SPECTATOR_LIST_CHANGED));
            EventStream?.Invoke(new EventPayload(EventType.PLAYER_SAT_DOWN, player));

            return (Seat)seatNumber + 1;
        }

        internal Seat OnPlayerStandUp(Player player)
        {
            if (!player.IsSittingDown()) { EventStream?.Invoke(new EventPayload(EventType.PLAYER_CANNOT_SIT, player)); return player.Seat; }

            RemovePlayerFromSeat(player);
            EventStream?.Invoke(new EventPayload(EventType.PLAYER_STOOD_UP, player));

            return Seat.SPECTATOR;
        }

        internal Seat OnPlayerLeave(Player player)
        {
            if (player.IsSittingDown()) { player.Stand(); }
            
            Spectators.Remove(player);
            EventStream?.Invoke(new EventPayload(EventType.SPECTATOR_LIST_CHANGED));
            EventStream?.Invoke(new EventPayload(EventType.PLAYER_LEFT_TABLE, player));

            return Seat.NONE;
        }

        public void OnPlayerReady(Player player) { 
            EventStream?.Invoke(new EventPayload(EventType.PLAYER_READY, player));

            if (!IsReadyToBegin()) { return; }
            EventStream?.Invoke(new EventPayload(EventType.GAME_WILL_START));
        }

        public void OnPlayerNotReady(Player player) { 
            EventStream?.Invoke(new EventPayload(EventType.PLAYER_NOT_READY, player));
        }

        private int GetFirstOpenSeat()
        {
            for (int i = 0; i < Players.Length; i++) { if (Players[i] == null) { return i; } }
            return -1;
        }

        private void RemovePlayerFromSeat(Player player)
        {
            var index = Array.IndexOf(Players, player);
            Players[index] = null;

            EventStream?.Invoke(new EventPayload(EventType.SPECTATOR_LIST_CHANGED));
        }

        protected abstract void Play();

        public void Start()
        {
            EventStream?.Invoke(new EventPayload(EventType.GAME_STARTED));
            Play();
        }

        public bool IsReadyToBegin() { return GetNumberOfPlayersReady() == Players.Length; }
        public int GetNumberOfPlayersReady() { return Players.Where(o => o != null && o.IsReady).Count(); }                
        public int GetNumberOfPlayers() { return GetNumberOfSpectators() + GetNumberOfSittingPlayers(); }
        public int GetNumberOfSpectators() { return Spectators.Count(); }
        public int GetNumberOfSittingPlayers() { return Players.Where(o => o != null).Count(); }
        public int GetNumberOfSeatsOpen() { return Players.Where(o => o == null).Count(); }
    }
}
