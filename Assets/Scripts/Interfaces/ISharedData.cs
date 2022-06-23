namespace TicTacToe.Interfaces
{
    public interface ISharedData
    {
        IGameState GameState { get; }
        IConfiguration Configuration { get; }
        IInput Input { get; set; }
        IEventsManager EventsManager { get; set; }
    }
}