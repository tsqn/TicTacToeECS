using Interfaces;
using Unity.Wrappers;
using UnityEngine;

namespace Unity
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