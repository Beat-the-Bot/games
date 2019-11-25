using Jarrus.Games.Players;
using Jarrus.TTT;

namespace Jarrus.TTTTests
{
    public class TTTHelper
    {
        public static TicTacToeGame GetGame(Agent player1, Agent player2)
        {
            var game = new TicTacToeGame();

            player1.Join(game);
            player2.Join(game);

            player1.Sit();
            player1.Ready();

            player2.Sit();
            player2.Ready();

            player1.SetSeed(35);
            player2.SetSeed(1);

            return game;
        }
    }
}
