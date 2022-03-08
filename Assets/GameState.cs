using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class GameState
{
    public SignType CurrentSign = SignType.Ring;
    public readonly Dictionary<Vector2Int, EcsEntity> Cells = new Dictionary<Vector2Int, EcsEntity>();
}