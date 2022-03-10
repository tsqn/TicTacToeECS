using Interfaces;

namespace Unity
{
    public class SharedData : ISharedData
    {
        public IGameState GameState { get; set; }
        public IConfiguration Configuration { get; set; }
        public ISceneData SceneData { get; set; }
        public IInput Input { get; set; }
        public IPhysics Physics { get; set; }
    }
}