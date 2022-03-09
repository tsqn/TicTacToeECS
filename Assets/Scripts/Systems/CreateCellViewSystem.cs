using Leopotam.EcsLite;
using TicTacToe.Components;
using TicTacToe.Components.Refs;
using TicTacToe.Unity;
using UnityEngine;

namespace TicTacToe.Systems
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<SharedData>();
            var configuration = sharedData.Configuration;

            var filter = world.Filter<Cell>().Inc<Position>().Exc<CellViewRef>().End();

            var positions = world.GetPool<Position>();
            var cellViewRefs = world.GetPool<CellViewRef>();

            foreach (var index in filter)
            {
                ref var position = ref positions.Get(index);

                var cellView = Object.Instantiate(configuration.CellView);

                cellView.transform.position = new Vector3(position.Value.x + configuration.Offset.x * position.Value.x,
                    position.Value.y + configuration.Offset.y * position.Value.y);

                cellView.Entity = index;

                ref var cellViewRef = ref cellViewRefs.Add(index);
                cellViewRef.View = cellView;
            }
        }
    }
}