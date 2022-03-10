using System;
using Core;
using Interfaces;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Unity.Wrappers
{
    public class WinScreenDecorator : Screen, IWinScreen
    {
        public Text Text;

        public void SetWinner(SignType winnerType)
        {
            Text.text = winnerType switch
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