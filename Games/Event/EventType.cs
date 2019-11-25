namespace Jarrus.Games.Event
{
    public enum EventType
    {
        GAME_WILL_START = 0,
        GAME_STARTED = 1,        
        PLAYER_JOINED_TABLE = 2,
        PLAYER_LEFT_TABLE = 3,
        PLAYER_SAT_DOWN = 4,
        PLAYER_STOOD_UP = 5,
        PLAYER_CANNOT_SIT = 6,
        PLAYER_READY = 7, 
        PLAYER_NOT_READY = 8,
        SPECTATOR_LIST_CHANGED = 9,
        PAUSE = 10,
        UNPAUSE = 11,
        PLAYER_ACTION_TAKEN = 12,
        PLAYER_INVALID_ACTION_ATTEMPTED = 13,
        PLAYER_ACTION_REQUIRED = 14,
        PLAYER_TURN_START = 15,
        PLAYER_TURN_COMPLETE = 16,
        SCORE_UPDATE = 17,
        ROUND_START = 18,
        ROUND_END = 19,
        GAME_WINNER = 998,
        GAME_COMPLETE = 999,
    }
}
