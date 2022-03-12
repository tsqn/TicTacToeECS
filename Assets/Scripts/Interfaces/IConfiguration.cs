using System.Numerics;

namespace TicTacToe.Interfaces
{
    public interface IConfiguration
    {
        int LevelWidth { get; }
        int LevelHeight { get; }
        int ChainLength { get; }
        ISignView CrossView { get; }
        ISignView RingView { get; }
        ICellView CellView { get; }
        Vector2 Offset { get; }
    }
}