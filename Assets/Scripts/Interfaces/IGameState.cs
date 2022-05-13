using System.Collections.Generic;
using System.Numerics;
using TicTacToe.Core;

namespace TicTacToe.Interfaces
{
    public interface IGameState
    {
        public SignType CurrentSign { get; set; }
        public Dictionary<Vector2, int> Cells { get; }
        public State State { get; set; }
    }
}