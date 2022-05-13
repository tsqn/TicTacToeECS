using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface IEventsManager
    {
        Queue<IEvent> Events { get; set; }
    }
}