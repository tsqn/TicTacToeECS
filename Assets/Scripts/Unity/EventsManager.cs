using System.Collections.Generic;
using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class EventsManager : MonoBehaviour, IEventsManager
    {
        public void Awake()
        {
            Events = new Queue<IEvent>();
        }

        public Queue<IEvent> Events { get; set; }
    }
}