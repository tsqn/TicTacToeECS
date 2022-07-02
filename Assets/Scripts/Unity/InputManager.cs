using TicTacToe.Logic.Messages;
using TicTacToe.Unity.Views;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class InputManager
    {
        private readonly MessagesBridge _messagesBridge;

        public InputManager(MessagesBridge messagesBridge)
        {
            _messagesBridge = messagesBridge;
        }

        public void Update()
        {
            if (LeftMouseButtonClicked)
            {
                TryHitCell();
            }
        }

        private void TryHitCell()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                var cellView = hitInfo.collider.GetComponent<CellView>();

                if (cellView != null)
                {
                    _messagesBridge.InputMessages.Enqueue(new ClickedCellViewMessage
                    {
                        Entity = cellView.EntityId
                    });
                }
            }
        }

        private static bool LeftMouseButtonClicked => Input.GetMouseButtonDown(0);
    }
}