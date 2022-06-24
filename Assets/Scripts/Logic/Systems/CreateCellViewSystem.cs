using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Tags;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class CreateCellViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;

            var filter = world.Filter<Cell>().Inc<CellPosition>().Exc<Created>().End();

            var cellPositions = world.GetPool<CellPosition>();
            var positions = world.GetPool<Position>();
            var created = world.GetPool<Created>();

            foreach (var index in filter)
            {
                
                ref var position = ref cellPositions.Get(index);
                ref var pos = ref positions.Add(index);
                created.Add(index);

                pos.Value = new Vector3(position.Value.X + configuration.Offset.X * position.Value.X,
                    position.Value.Y + configuration.Offset.Y * position.Value.Y, 0);

                sharedData.EventsManager.OutputMessages.Enqueue(new InstantiateCellViewMessage()
                {
                    EntityId = index,
                    Position = pos.Value,
                });
            }
        }
    }

    public struct Created
    {
    }
}