using TicTacToe.Interfaces;
using TicTacToe.Unity.Wrappers;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class SceneData : MonoBehaviour, ISceneData
    {
        [SerializeField] 
        private CameraDecorator _camera;

        [SerializeField] 
        private UIDecorator _ui;

        public ITransform CameraTransform => _camera ;
        public ICamera Camera => _camera;
        public IUI UI => _ui;
    }
}