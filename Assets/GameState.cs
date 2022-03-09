using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public SignType CurrentSign = SignType.Ring;
    public readonly Dictionary<Vector2Int, int> Cells = new Dictionary<Vector2Int, int>();
}