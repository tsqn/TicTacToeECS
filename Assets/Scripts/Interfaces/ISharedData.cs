using System.Collections.Generic;

namespace TicTacToe.Interfaces
{
    public interface ISharedData
    {
        IGameState GameState { get; }
        IConfiguration Configuration { get; }
        ISceneData SceneData { get; }
        IInput Input { get; set; }
        IEventsManager EventsManager { get; set; } 
        IPhysics Physics { get; set; }
    }
}