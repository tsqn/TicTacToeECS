using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Components.Tags;
using TicTacToe.Logic.Extensions;

namespace TicTacToe.Logic.Systems
{
    public class RestartSystem : IEcsRunSystem
    {
        private EcsCustomInject<ILogger> _logger;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var sharedData = systems.GetShared<ISharedData>();
            
            var deleteTagsRef = world.GetPool<DeleteTag>();
            
            var signFilter = world.Filter<Sign>().End();

            var restartFilter = world.Filter<RestartEvent>().End();

            var restartEventsCount = restartFilter.GetEntitiesCount();
            
            if (restartEventsCount is not (0 or 1))
            {
                _logger.Error($"Invalid restart events count {restartEventsCount}");
            }
            
            if (restartEventsCount == 1)
            {
                foreach (var id in signFilter)
                {
                    deleteTagsRef.Add(id);
                }

                sharedData.GameState.State = State.Playing;
                
                world.DelEntity(restartFilter.GetRawEntities()[0]);
            }
        }
    }
}