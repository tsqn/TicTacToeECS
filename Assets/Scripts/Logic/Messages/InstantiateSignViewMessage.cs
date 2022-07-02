using System.Numerics;
using TicTacToe.Core;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public class InstantiateSignViewMessage : IMessage
    {
        public int Id { get; set; }
        public Vector3 Position { get; set; }
        public SignType SignType { get; set; }
    }
}