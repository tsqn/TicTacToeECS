using TicTacToe.Interfaces;
using TicTacToe.Unity.Decorators;
using UnityEngine;

namespace TicTacToe.Unity.Views
{
    public class SignView : MonoBehaviour
    {
        [SerializeField]
        private int _entityId;
        
        public int EntityId
        {
            get => _entityId;
            set => _entityId = value;
        }
    }
}