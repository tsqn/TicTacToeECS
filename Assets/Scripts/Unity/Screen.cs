using UnityEngine;

namespace TicTacToe.Unity
{
    public class Screen : MonoBehaviour
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}