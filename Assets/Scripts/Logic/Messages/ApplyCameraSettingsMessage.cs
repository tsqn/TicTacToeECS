using System.Numerics;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Messages
{
    public class ApplyCameraSettingsMessage : IMessage
    {
        public bool Orthographic { get; set; }
        public float OrthographicSize { get; set; }
        public Vector3 Position { get; set; }
    }
}