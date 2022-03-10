using Interfaces;
using Unity.Extensions;
using UnityEngine;

namespace Unity.Wrappers
{
    public class PhysicsDecorator : IPhysics
    {
        public bool Raycast(IRay ray, out IHitInfo hitInfoResult)
        {
            var newRay = new Ray(ray.Origin.Convert(), ray.Destination.Convert());

            var hit = Physics.Raycast(newRay, out var hitInfo);

            hitInfoResult = new HitInfoDecorator(hitInfo);

            return hit;
        }
    }
}