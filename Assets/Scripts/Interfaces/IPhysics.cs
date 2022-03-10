using System.Numerics;

namespace Interfaces
{
    public interface IPhysics
    {
        bool Raycast(IRay ray, out IHitInfo hitInfoResult);
    }

    public interface IHitInfo
    {
        ICollider Collider { get; set; }
    }

    public interface ICollider
    {
        IObject GetComponent<T>();
    }

    public interface IRay
    {
        public Vector3 Origin { get; }
        public Vector3 Destination { get; }

    }
}