using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class GameState
    {
        public readonly Dictionary<Vector2Int, int> Cells = new();
        public SignType CurrentSign = SignType.Ring;
    }
}