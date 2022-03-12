using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity.Wrappers
{
    public class ColliderDecorator : ICollider
    {
        private readonly Collider _collider;

        public ColliderDecorator(Collider collider)
        {
            _collider = collider;
        }

        public IObject GetComponent<T>()
        {
            return (IObject) _collider.GetComponent<T>();
        }
    }
}