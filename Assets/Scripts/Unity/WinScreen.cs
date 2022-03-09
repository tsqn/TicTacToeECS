using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe.Unity
{
    public class WinScreen : Screen
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