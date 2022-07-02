using System.Collections.Generic;
using TicTacToe.Interfaces;

namespace TicTacToe.Unity
{
    public class MessagesBridge : IEventsManager
    {
        private MessagesBridge()
        {
            
        }

        private static MessagesBridge _instance;
        public static MessagesBridge Instance => _instance ??= new MessagesBridge();

        public Queue<IMessage> OutputMessages { get; set; } = new();
        public Queue<IMessage> InputMessages { get; set; } = new();
    }
}