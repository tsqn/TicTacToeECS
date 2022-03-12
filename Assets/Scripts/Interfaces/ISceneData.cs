namespace TicTacToe.Interfaces
{
    public interface ISceneData
    {
        IUI UI { get; }
        ITransform CameraTransform { get; }
        ICamera Camera { get; }
    }
}