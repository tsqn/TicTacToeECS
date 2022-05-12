using TicTacToe.Interfaces;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TicTacToe.Unity.Wrappers
{
    public class MonoDecorator : MonoBehaviour, IObject, ITransform
    {
        public object Instantiate(int id)
        {
            var newObject = Instantiate(this);
            Synchronizer.Instance.AddObject(id, newObject);
            return newObject;
        }

        public object Instantiate(int id, Vector3 vector3)
        {
            var newObject = Instantiate(this, vector3.Convert(), Quaternion.identity);
            Synchronizer.Instance.AddObject(id, newObject);
            return newObject;
        }

        public Vector3 Position
        {
            get => transform.position.Convert();
            set => transform.position = value.Convert();
        }
    }
}