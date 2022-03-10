using Interfaces;
using UnityEngine;

namespace Unity.Wrappers
{
    public class HitInfoDecorator : IHitInfo
    {
        public HitInfoDecorator(RaycastHit info)
        {
            Collider = new ColliderDecorator(info.collider);
        }

        public ICollider Collider { get; set; }
    }
}