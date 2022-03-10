using Interfaces;
using Leopotam.EcsLite;
using Logic.Components;
using Logic.Components.Refs;

namespace Logic.Systems
{
    public class CreateCellViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;

            var filter = world.Filter<Cell>().Inc<Position>().Exc<CellViewRef>().End();

            var positions = world.GetPool<Position>();
            var cellViewRefs = world.GetPool<CellViewRef>();

            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);

                var cellView = (ICellView)configuration.CellView.Instantiate();

                cellView.Position = new System.Numerics.Vector3(position.Value.X + configuration.Offset.X * position.Value.X,
                    position.Value.Y + configuration.Offset.Y * position.Value.Y, 0);

                cellView.Entity = index;

                ref var cellViewRef = ref cellViewRefs.Add(index);
                cellViewRef.View = cellView;
            }
        }
    }
}