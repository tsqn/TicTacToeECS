using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Unity.Decorators
{
    public class UIDecorator : Screen, IUI
    {
        [SerializeField]
        private WinScreenDecorator _winScreenDecorator;

        public IWinScreen WinScreen
        {
            get => _winScreenDecorator;
            set => _winScreenDecorator = (WinScreenDecorator) value;
        }
    }
}