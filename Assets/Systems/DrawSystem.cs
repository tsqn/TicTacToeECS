using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<SharedData>();
            var sceneData = sharedData.SceneData;
            
            var world = systems.GetWorld();
            
            var cellsFilter = world.Filter<Cell>().Exc<Taken>().End();
            var winnerFilter = world.Filter<Winner>().End();

            var cells = world.GetPool<Cell>();

            if (cellsFilter.GetEntitiesCount() == 0 && winnerFilter.GetEntitiesCount() == 0)
            {
                sceneData.UI.WinScreen.Show(true);
                sceneData.UI.WinScreen.SetWinner(SignType.None);
            }
        }
    }
}