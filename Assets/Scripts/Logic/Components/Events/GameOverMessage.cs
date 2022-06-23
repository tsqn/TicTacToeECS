using TicTacToe.Core;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Components.Events
{
    public struct GameOverMessage : IMessage
    {
        public SignType Result;
    }
}