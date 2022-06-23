using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface IEventsManager
    {
        Queue<IMessage> InputEvents { get; set; }
        Queue<IMessage> OutputEvents { get; set; }
    }
}