using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class Screen : MonoBehaviour, IScreen
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}