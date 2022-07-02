using UnityEngine;

namespace TicTacToe.Unity
{
    public class SceneData : MonoBehaviour
    {

        [SerializeField]
        private UIController _uiController;

        public UIController UIController => _uiController;
    }
}