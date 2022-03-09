using Leopotam.EcsLite;
using TicTacToe.Components.Events;
using TicTacToe.Unity;
using UnityEngine;

namespace TicTacToe.Systems
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<SharedData>();
            var sceneData = sharedData.SceneData;
            var configuration = sharedData.Configuration;

            var world = systems.GetWorld();

            var cellsFilter = world.Filter<UpdateCameraEvent>().End();
            var updateCameraEvents = world.GetPool<UpdateCameraEvent>();

            foreach (var id in cellsFilter)
            {
                var height = configuration.LevelHeight;

                var camera = sceneData.Camera;
                camera.orthographic = true;
                camera.orthographicSize = height / 1.5f + (height - 1) * configuration.Offset.y / 1.5f;

                sceneData.CameraTransform.position = new Vector3(
                    configuration.LevelWidth / 2f + (configuration.LevelWidth - 1) * configuration.Offset.y / 2,
                    configuration.LevelHeight / 2f + (configuration.LevelHeight - 1) * configuration.Offset.y / 2,
                    -1);

                updateCameraEvents.Del(id);
            }
        }
    }
}