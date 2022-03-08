using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter;
        private GameState _gameState;
        private Configuration _configuration;

        public void Run()
        {

            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index);

                var chainLenght = _gameState.Cells.GetLongestChain(position.Value);

                if (chainLenght >= _configuration.ChainLength)
                {
                    _filter.GetEntity(index).Get<Winner>();
                }
            }
            
            if (!_filter.IsEmpty())
            {
                
            }
        }
    }
}