using System.Numerics;

namespace TicTacToe.Unity.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 Convert(this UnityEngine.Vector2 input)
        {
            return new Vector2(input.x, input.y);
        }
        
        public static UnityEngine.Vector2 Convert(this Vector2 input)
        {
            return new UnityEngine.Vector2(input.X, input.Y);
        }
    }
}