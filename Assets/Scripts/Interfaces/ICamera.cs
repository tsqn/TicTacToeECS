using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface ICamera
    {
        bool Orthographic { get; set; }
        float OrthographicSize { get; set; }
        IRay ScreenPointToRay(Vector3 mousePosition);
    }
}