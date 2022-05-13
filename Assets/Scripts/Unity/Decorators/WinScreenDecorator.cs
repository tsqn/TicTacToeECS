using System;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe.Unity.Decorators
{
    public class WinScreenDecorator : Screen, IWinScreen
    {
        [SerializeField]
        public Text _text;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}