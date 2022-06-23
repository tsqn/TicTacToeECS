﻿using System;
using TicTacToe.Core;
using TicTacToe.Logic.Components.Events;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Unity.Decorators
{
    public class WinScreen : Screen
    {
        [SerializeField]
        private Text _text;

        [SerializeField]
        private MessagesBridge _messagesBridge;

        public void SetWinner(SignType winnerType)
        {
            _text.text = winnerType switch
            {
                SignType.None => "Draw",
                SignType.Cross => "Cross wins",
                SignType.Ring => "Ring wins",
                _ => throw new ArgumentOutOfRangeException(nameof(winnerType), winnerType, null)
            };
            Show();
        }

        public void OnRestartClick()
        {
            _messagesBridge.InputEvents.Enqueue(new RestartMessage());
            Hide();
        }
    }
}