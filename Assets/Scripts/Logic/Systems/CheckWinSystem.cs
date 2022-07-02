using System;
using System.Collections.Generic;
using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Components.Tags;
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

            var newToSignFilter = world.Filter<CellPosition>().Inc<Sign>().Inc<CheckWinEvent>().End();
            var alreadySignedFilter = world.Filter<CellPosition>().Inc<Sign>().End();
            var cellsPositionFilter = world.Filter<CellPosition>().End();

            var positions = world.GetPool<CellPosition>();
            var signs = world.GetPool<Sign>();
            var eventPool = world.GetPool<CheckWinEvent>();

            foreach (var id in newToSignFilter)
            {
                ref var newSignPosition = ref positions.Get(id);

                var signedCells = new Dictionary<Vector2, SignType>();

                foreach (var cellPositionId in cellsPositionFilter)
                {
                    ref var cellPosition = ref positions.Get(cellPositionId);
                    
                    signedCells.Add(cellPosition.Value, SignType.None);
                }

                foreach (var alreadySignedId in alreadySignedFilter)
                {
                    ref var sign = ref signs.Get(alreadySignedId);
                    ref var position = ref positions.Get(alreadySignedId);

                    signedCells[position.Value] = sign.Type;
                }

                var chainLength = signedCells.GetLongestChain(newSignPosition.Value);

                if (chainLength >= configuration.ChainLength)
                {
                    Win(world, id);
                }
                else if (cellsPositionFilter.GetEntitiesCount() == 0)
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