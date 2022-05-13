using System;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components.Events;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Unity.Decorators
{
    public class WinScreenDecorator : Screen, IWinScreen
    {
        [SerializeField]
        private Text _text;

        [SerializeField]
        private EventsManager _eventsManager;

        public void SetWinner(SignType winnerType)
        {
            _text.text = winnerType switch
            {
                SignType.None => "Draw",
                SignType.Cross => "Cross wins",
                SignType.Ring => "Ring wins",
                _ => throw new ArgumentOutOfRangeException(nameof(winnerType), winnerType, null)
            };
        }

        public void OnRestartClick()
        {
            _eventsManager.Events.Enqueue(new RestartEvent());
            Hide();
        }
    }
}