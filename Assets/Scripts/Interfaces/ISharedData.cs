namespace Interfaces
{
    public interface ISharedData
    {
        IGameState GameState { get; }
        IConfiguration Configuration { get; }
        ISceneData SceneData { get; }
        IInput Input { get; set; }
        IPhysics Physics { get; set; }
    }
}