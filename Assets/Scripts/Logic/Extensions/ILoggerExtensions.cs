using Leopotam.EcsLite.Di;
using TicTacToe.Interfaces;

namespace TicTacToe.Logic.Extensions
{
    public static class LoggerExtensions
    {
        public static void Debug(this EcsCustomInject<ILogger> logger, object message)
        {
            logger.Value.Debug(message);
        }

        public static void Error(this EcsCustomInject<ILogger> logger, object message)
        {
            logger.Value.Error(message);
        }

        public static void Warning(this EcsCustomInject<ILogger> logger, object message)
        {
            logger.Value.Warning(message);
        }
    }
}