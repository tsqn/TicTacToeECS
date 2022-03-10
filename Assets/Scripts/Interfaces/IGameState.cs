using System.Collections.Generic;
using System.Numerics;
using Core;

namespace Interfaces
{
    public interface IGameState
    {
        public SignType CurrentSign { get; set; }
        public Dictionary<Vector2, int> Cells { get; }
    }
}