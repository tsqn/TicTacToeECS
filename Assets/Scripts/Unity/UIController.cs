using TicTacToe.Unity.Decorators;
using TicTacToe.Unity.UI;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private WinScreen _winScreen;

        public WinScreen WinScreen => _winScreen;
    }
}