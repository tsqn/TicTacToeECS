using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Systems
{
    public class WinScreen : Screen
    {
        public Text Text;
        
        public void SetWinner(SignType winnerType)
        {
            switch (winnerType)
            {
                case SignType.None:
                    Text.text = "Draw";
                    break;
                case SignType.Cross:
                    Text.text = "Cross wins";
                    break;
                case SignType.Ring:
                    Text.text = "Ring wins";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winnerType), winnerType, null);
            }
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}