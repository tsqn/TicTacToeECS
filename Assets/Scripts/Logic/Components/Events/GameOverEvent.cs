using TicTacToe.Core;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Components.Events
{
    public struct GameOverEvent : IEvent
    {
        public SignType Result;
    }
}