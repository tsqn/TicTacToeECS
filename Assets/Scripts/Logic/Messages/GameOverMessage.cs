using TicTacToe.Core;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public struct GameOverMessage : IMessage
    {
        public SignType Result;
    }
}