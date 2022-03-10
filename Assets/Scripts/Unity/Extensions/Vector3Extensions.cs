using System.Numerics;

namespace Unity.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 Convert(this UnityEngine.Vector3 input)
        {
            return new Vector3(input.x, input.y, input.z);
        }

        public static UnityEngine.Vector3 Convert(this Vector3 input)
        {
            return new UnityEngine.Vector3(input.X, input.Y, input.Z);
        }
    }
}