using System.Numerics;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public class RequestScreenPointToRayMessage : IMessage
    {
        public Vector3 Position { get; set; }
    }
}