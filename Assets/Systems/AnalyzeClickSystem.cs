using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {

        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;

        public void Run()
        {
            foreach (var index in _filter)
            {
                _filter.GetEntity(index).Get<Taken>().value = _gameState.CurrentSign;
                _filter.GetEntity(index).Get<CheckWinEvent>();

                _gameState.CurrentSign = _gameState.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;
            }
        }
    }
}