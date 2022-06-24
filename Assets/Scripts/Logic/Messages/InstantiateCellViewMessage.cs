using System.Numerics;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public class InstantiateCellViewMessage : IMessage
    {
        public int EntityId { get; set; }
        public Vector3 Position { get; set; }
    }
}