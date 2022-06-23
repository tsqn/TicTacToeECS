using System.Collections.Generic;
using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class MessagesBridge : MonoBehaviour, IEventsManager
    {
        public void Awake()
        {
            InputEvents = new Queue<IMessage>();
            OutputEvents = new Queue<IMessage>();
        }

        public Queue<IMessage> OutputEvents { get; set; }
        public Queue<IMessage> InputEvents { get; set; }
    }
}