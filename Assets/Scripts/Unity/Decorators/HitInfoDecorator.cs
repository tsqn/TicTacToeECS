﻿using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity.Decorators
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