using TicTacToe.Interfaces;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace TicTacToe.Unity.Wrappers
{
    public class InputDecorator : IInput
    {
        public bool GetMouseButtonDown(int i)
        {
            return Input.GetMouseButton(i);
        }

        public Vector3 MousePosition => Input.mousePosition.Convert();
    }
}