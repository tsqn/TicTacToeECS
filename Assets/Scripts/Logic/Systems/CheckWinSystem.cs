using Interfaces;
using Leopotam.EcsLite;
using Logic.Components;
using Logic.Components.Events;
using Logic.Extensions;

namespace Logic.Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;

            var filter = world.Filter<Position>().Inc<Taken>().Inc<CheckWinEvent>().End();

            var positions = world.GetPool<Position>();
            var winner = world.GetPool<Winner>();
            var eventPool = world.GetPool<CheckWinEvent>();

            foreach (var id in filter)
            {
                ref var position = ref positions.Get(id);

                var chainLength = sharedData.GameState.Cells.GetLongestChain(world, position.Value);

                if (chainLength >= configuration.ChainLength)
                {
                    winner.Add(id);
                }

                eventPool.Del(id);
            }
        }
    }
}