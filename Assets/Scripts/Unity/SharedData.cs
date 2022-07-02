using TicTacToe.Interfaces;

namespace TicTacToe.Unity
{
    public class SharedData : ISharedData
    {
        public IGameState GameState { get; set; }
        public IConfiguration Configuration { get; set; }
        public IEventsManager MessagesBridge { get; set; }
    }
}