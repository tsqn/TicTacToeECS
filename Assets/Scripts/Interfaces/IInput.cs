using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface IInput
    {
        Vector3 MousePosition { get; }
        bool GetMouseButtonDown(int i);
    }
}