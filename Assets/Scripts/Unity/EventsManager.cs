using System;
using System.Collections.Generic;
using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class EventsManager : MonoBehaviour, IEventsManager
    {
        public Queue<IEvent> Events { get; set; }

        public void Awake()
        {
            Events = new Queue<IEvent>();
        }
    }
}