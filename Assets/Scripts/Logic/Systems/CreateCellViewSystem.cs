using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Refs;

namespace TicTacToe.Logic.Systems
{
    public class CreateCellViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;

            var filter = world.Filter<Cell>().Inc<CellPosition>().Exc<CellViewRef>().End();

            var cellPositions = world.GetPool<CellPosition>();
            var positions = world.GetPool<Position>();
            var cellViewRefs = world.GetPool<CellViewRef>();

            foreach (var index in filter)
            {
                ref var position = ref cellPositions.Get(index);
                ref var pos = ref positions.Add(index);

                pos.Value = new Vector3(position.Value.X + configuration.Offset.X * position.Value.X,
                    position.Value.Y + configuration.Offset.Y * position.Value.Y, 0);

                var cellView = (ICellView) configuration.CellView.Instantiate(index, pos.Value);

                ref var cellViewRef = ref cellViewRefs.Add(index);
                cellViewRef.View = cellView;
            }
        }
    }
}