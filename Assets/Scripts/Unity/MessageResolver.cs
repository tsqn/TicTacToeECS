using System;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Unity.Decorators;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class MessageResolver
    {
        public MessagesBridge MessagesBridge;
        public WinScreen WinScreen;

        public void Update()
        {
            while (MessagesBridge.OutputEvents.TryDequeue(out var result))
            {
                Debug.Log($"{result.GetType()} event occured.");
                switch (result)
                {
                    case GameOverMessage gameOverEvent:
                        WinScreen.SetWinner(gameOverEvent.Result);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(result));
                }
            }
        }
    }
}