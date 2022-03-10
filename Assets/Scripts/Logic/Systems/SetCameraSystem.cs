using System.Numerics;
using Interfaces;
using Leopotam.EcsLite;
using Logic.Components.Events;

namespace Logic.Systems
{
    public class SetCameraSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();
            var sceneData = sharedData.SceneData;
            var configuration = sharedData.Configuration;

            var world = systems.GetWorld();

            var cellsFilter = world.Filter<UpdateCameraEvent>().End();
            var updateCameraEvents = world.GetPool<UpdateCameraEvent>();

            foreach (var id in cellsFilter)
            {
                var height = configuration.LevelHeight;

                var camera = sceneData.Camera;
                camera.Orthographic = true;
                camera.OrthographicSize = height / 1.5f + (height - 1) * configuration.Offset.Y / 1.5f;

                sceneData.CameraTransform.Position = new Vector3(
                    configuration.LevelWidth / 2f + (configuration.LevelWidth - 1) * configuration.Offset.Y / 2,
                    configuration.LevelHeight / 2f + (configuration.LevelHeight - 1) * configuration.Offset.Y / 2,
                    -1);

                updateCameraEvents.Del(id);
            }
        }
    }
}