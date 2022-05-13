using System;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Unity.Decorators;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class EventsResolver
    {
        public EventsManager EventsManager;
        public WinScreen WinScreen;
        
        public void Update()
        {
            if (EventsManager.OutputEvents.TryDequeue(out var result))
            {
                Debug.Log($"{result.GetType()} event occured.");
                switch (result)
                {
                    case GameOverEvent gameOverEvent:
                        
                        WinScreen.SetWinner(gameOverEvent.Result);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(result));
                }
            }
        }
    }
}