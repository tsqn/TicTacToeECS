using TicTacToe.Interfaces;

namespace TicTacToe.Unity
{
    public class SharedData : ISharedData
    {
        public IGameState GameState { get; set; }
        public IConfiguration Configuration { get; set; }
        public IInput Input { get; set; }
        public IEventsManager EventsManager { get; set; }
    }
}