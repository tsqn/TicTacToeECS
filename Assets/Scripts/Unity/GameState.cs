using System.Collections.Generic;
using System.Numerics;
using TicTacToe.Core;
using TicTacToe.Interfaces;

namespace TicTacToe.Unity
{
    public class GameState : IGameState
    {
        public SignType CurrentSign { get; set; } = SignType.Ring;
        public Dictionary<Vector2, int> Cells { get; } = new();
    }
}