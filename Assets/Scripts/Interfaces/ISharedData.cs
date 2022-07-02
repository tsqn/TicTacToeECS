namespace TicTacToe.Interfaces
{
    public interface ISharedData
    {
        IGameState GameState { get; }
        IConfiguration Configuration { get; }
        IEventsManager MessagesBridge { get; set; }
    }
}