using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Winner, Taken> _filter;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var winnerType = ref _filter.Get2(index).value;
                
                _sceneData.UI.WinScreen.Show(true);
                _sceneData.UI.WinScreen.SetWinner(winnerType);
            }
        }
    }
}