using Interfaces;
using UnityEngine;

namespace Unity.Wrappers
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