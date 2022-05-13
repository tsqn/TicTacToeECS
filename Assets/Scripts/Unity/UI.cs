using TicTacToe.Unity.Decorators;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private WinScreen _winScreen;

        public WinScreen WinScreen => _winScreen;
    }
}