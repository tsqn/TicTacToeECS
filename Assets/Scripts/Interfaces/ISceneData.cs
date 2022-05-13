namespace TicTacToe.Interfaces
{
    public interface ISceneData
    {
        ITransform CameraTransform { get; }
        ICamera Camera { get; }
    }
}