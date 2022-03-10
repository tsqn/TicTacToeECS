using Core;

namespace Interfaces
{
    public interface IWinScreen : IScreen
    {
        void SetWinner(SignType winnerType);
    }
}