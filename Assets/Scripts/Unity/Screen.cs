using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class Screen : MonoBehaviour, IScreen
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}