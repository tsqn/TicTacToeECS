using System;
using TicTacToe.Interfaces;

namespace TicTacToe.Unity
{
    public class SharedData : ISharedData, IDisposable
    {
        public IGameState GameState { get; set; }
        public IConfiguration Configuration { get; set; }
        public ISceneData SceneData { get; set; }
        public IInput Input { get; set; }
        public IPhysics Physics { get; set; }
        public IServer Server { get; set; }

        public void Dispose()
        {
            Server?.Dispose();
            Server = null;
            GC.Collect();
        }
    }
}