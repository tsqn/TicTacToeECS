using System;
using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Extensions;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;

            var filter = world.Filter<CellPosition>().Inc<Sign>().Inc<CheckWinEvent>().End();

            var positions = world.GetPool<CellPosition>();
            var eventPool = world.GetPool<CheckWinEvent>();

            var cellsFilter = world.Filter<Cell>().Exc<Sign>().End();

            foreach (var id in filter)
            {
                ref var position = ref positions.Get(id);

                var chainLength = sharedData.GameState.Cells.GetLongestChain(world, position.Value);

                if (chainLength >= configuration.ChainLength)
                {
                    Win(world, id);
                }
                else if (cellsFilter.GetEntitiesCount() == 0)
                {
                    Draw(world);
                }

                eventPool.Del(id);
            }
        }

        private static void Draw(EcsWorld world)
        {
            world.GetPool<GameOverMessage>().Add(world.NewEntity()).Result = SignType.None;
        }

        private static void Win(EcsWorld world, int id)
        {
            world.GetPool<GameOverMessage>().Add(world.NewEntity()).Result =
                world.GetPool<Sign>().Get(id).Type switch
                {
                    SignType.None => throw new ArgumentOutOfRangeException(),
                    SignType.Cross => SignType.Cross,
                    SignType.Ring => SignType.Ring,
                    _ => throw new ArgumentOutOfRangeException()
                };
        }
    }
}