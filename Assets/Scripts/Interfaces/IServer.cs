using System;

namespace TicTacToe.Interfaces
{
    public interface IServer : IDisposable
    {
        public void SendWorldStateMessage(object state);
    }
}