using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<Cell>.Exclude<Taken> _freeCells;
        private EcsFilter<Winner> _winner;
        private SceneData _sceneData;

        public void Run()
        {
            if (_freeCells.IsEmpty() && _winner.IsEmpty())
            {
                _sceneData.UI.WinScreen.Show(true);
                _sceneData.UI.WinScreen.SetWinner(SignType.None);
            }
        }
    }
}