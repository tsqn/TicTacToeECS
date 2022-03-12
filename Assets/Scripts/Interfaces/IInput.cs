using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface IInput
    {
        bool GetMouseButtonDown(int i);
        Vector3 MousePosition { get; }
    }
}