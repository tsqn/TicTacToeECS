using Leopotam.EcsLite;
using TicTacToe.Components;
using TicTacToe.Components.Events;
using TicTacToe.Extensions;
using TicTacToe.Unity;

namespace TicTacToe.Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<SharedData>();
            var configuration = sharedData.Configuration;
            var gameState = sharedData.GameState;

            var filter = world.Filter<Position>().Inc<Taken>().Inc<CheckWinEvent>().End();

            var positions = world.GetPool<Position>();
            var winner = world.GetPool<Winner>();
            var eventPool = world.GetPool<CheckWinEvent>();

            foreach (var id in filter)
            {
                ref var position = ref positions.Get(id);

                var chainLength = gameState.Cells.GetLongestChain(world, position.Value);

                if (chainLength >= configuration.ChainLength)
                {
                    winner.Add(id);
                }

                eventPool.Del(id);
            }
        }
    }
}