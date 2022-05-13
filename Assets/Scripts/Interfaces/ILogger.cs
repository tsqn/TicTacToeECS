namespace TicTacToe.Interfaces
{
    public interface ILogger
    {
        void Debug(object message);
        void Error(object message);
        void Warning(object message);
    }
}