using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class SetCameraSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;

            var world = systems.GetWorld();

            var filter = world.Filter<UpdateCameraEvent>().End();
            var updateCameraEvents = world.GetPool<UpdateCameraEvent>();

            foreach (var id in filter)
            {
                var levelHeight = configuration.LevelHeight;
                var levelWidth = configuration.LevelWidth;
                var offset = configuration.Offset;

                sharedData.EventsManager.OutputMessages.Enqueue(new ApplyCameraSettingsMessage
                {
                    Orthographic = true,
                    OrthographicSize = levelHeight / 1.5f + (levelHeight - 1) * offset.Y / 1.5f,
                    Position = new Vector3(levelWidth / 2f + (levelWidth - 1) * offset.Y / 2,
                        levelHeight / 2f + (levelHeight - 1) * offset.Y / 2, -1)
                });
                updateCameraEvents.Del(id);
            }
        }
    }
}