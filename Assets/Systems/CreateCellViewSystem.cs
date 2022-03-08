using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;

        private Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_configuration.CellView);

                cellView.transform.position = new Vector3(position.Value.x + _configuration.Offset.x * position.Value.x,
                    position.Value.y + _configuration.Offset.y * position.Value.y);

                cellView.Entity = _filter.GetEntity(index);
                
                _filter.GetEntity(index).Get<CellViewRef>().View = cellView;
            }
        }
    }
}