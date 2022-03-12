using System.Collections.Generic;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using Vector2 = System.Numerics.Vector2;

namespace TicTacToe.Unity
{
    public class GameState : IGameState
    {
        private readonly Dictionary<Vector2, int> _cells = new();

        public SignType CurrentSign { get; set; } = SignType.Ring;
        public Dictionary<Vector2 , int> Cells => _cells;
    }
}