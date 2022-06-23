using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface IEventsManager
    {
        Queue<IMessage> InputMessages { get; set; }
        Queue<IMessage> OutputMessages { get; set; }
    }
}