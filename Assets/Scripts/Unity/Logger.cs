using TicTacToe.Interfaces;

namespace TicTacToe.Unity
{
    public class Logger : ILogger
    {
        public bool WriteDebugToUnityConsole;
        public bool WriteErrorsToUnityConsole;
        public bool WriteToUnityConsole;
        public bool WriteWarningToUnityConsole;

        public void Debug(object message)
        {
            if (WriteToUnityConsole && WriteDebugToUnityConsole)
            {
                UnityEngine.Debug.Log(message);
            }
        }

        public void Error(object message)
        {
            if (WriteToUnityConsole && WriteErrorsToUnityConsole)
            {
                UnityEngine.Debug.LogError(message);
            }
        }

        public void Warning(object message)
        {
            if (WriteToUnityConsole && WriteWarningToUnityConsole)
            {
                UnityEngine.Debug.LogWarning(message);
            }
        }
    }
}