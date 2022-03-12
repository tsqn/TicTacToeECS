using TicTacToe.Interfaces;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TicTacToe.Unity.Wrappers
{
    public class MonoDecorator : MonoBehaviour, IObject, ITransform
    {
        public object Instantiate()
        {
            return Object.Instantiate(this);
        }

        public object Instantiate(Vector3 vector3)
        {
            return Object.Instantiate(this, vector3.Convert(), Quaternion.identity);
        }

        public Vector3 Position
        {
            get => transform.position.Convert();
            set => transform.position = value.Convert();
        }
    }
    
}