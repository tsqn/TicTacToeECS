using UnityEngine;

namespace TicTacToe.Unity.Views
{
    public class CellView : MonoBehaviour
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