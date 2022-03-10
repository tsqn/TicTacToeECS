using System.Numerics;

namespace Interfaces
{
    public interface IInput
    {
        bool GetMouseButtonDown(int i);
        Vector3 MousePosition { get; }
    }
}