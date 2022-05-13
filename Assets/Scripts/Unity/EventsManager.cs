using System.Collections.Generic;
using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class EventsManager : MonoBehaviour, IEventsManager
    {
        public void Awake()
        {
            InputEvents = new Queue<IEvent>();
            OutputEvents = new Queue<IEvent>();
        }

        public Queue<IEvent> OutputEvents { get; set; }

        public Queue<IEvent> InputEvents { get; set; }
    }
}