using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> _filter;
        private Configuration _configuration;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                var height = _configuration.LevelHeight;
                
                var camera = _sceneData.Camera;
                camera.orthographic = true;
                camera.orthographicSize = height / 1.5f + (height - 1) * _configuration.Offset.y / 1.5f;

                _sceneData.CameraTransform.position = new Vector3(
                    _configuration.LevelWidth / 2f + (_configuration.LevelWidth - 1) * _configuration.Offset.y / 2,
                    _configuration.LevelHeight / 2f + (_configuration.LevelHeight - 1) * _configuration.Offset.y / 2, -1);
            }
        }
    }
}