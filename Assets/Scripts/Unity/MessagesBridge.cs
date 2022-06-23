using System.Collections.Generic;
using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class MessagesBridge : MonoBehaviour, IEventsManager
    {
        public void Awake()
        {
            InputMessages = new Queue<IMessage>();
            OutputMessages = new Queue<IMessage>();
        }

        public Queue<IMessage> OutputMessages { get; set; }
        public Queue<IMessage> InputMessages { get; set; }
    }
}