using TicTacToe.Interfaces;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TicTacToe.Unity.Decorators
{
    public class MonoDecorator : MonoBehaviour, IObject, ITransform, IEntity
    {
        [SerializeField]
        private int _entity;

        public int Entity
        {
            get => _entity;
            set => _entity = value;
        }

        public object Instantiate(int id)
        {
            var newObject = Instantiate(this);
            newObject.Entity = id;
            return newObject;
        }

        public object Instantiate(int id, Vector3 vector3)
        {
            var newObject = Instantiate(this, vector3.Convert(), Quaternion.identity);
            newObject.Entity = id;
            return newObject;
        }

        public Vector3 Position
        {
            get => transform.position.Convert();
            set => transform.position = value.Convert();
        }
    }

    public interface IEntity
    {
        public int Entity { get; set; }
    }
}