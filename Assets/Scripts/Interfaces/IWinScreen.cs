using TicTacToe.Core;

namespace TicTacToe.Interfaces
{
    public interface IWinScreen : IScreen
    {
        void SetWinner(SignType winnerType);
    }
}