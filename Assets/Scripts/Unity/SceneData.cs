using TicTacToe.Interfaces;
using TicTacToe.Unity.Decorators;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class SceneData : MonoBehaviour
    {

        [SerializeField]
        private UI _ui;

        public UI UI => _ui;
    }
}