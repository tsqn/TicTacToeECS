using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface IEventsManager
    {
        Queue<IEvent> InputEvents { get; set; }
        Queue<IEvent> OutputEvents { get; set; }
    }
}