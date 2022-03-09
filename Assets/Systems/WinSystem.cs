using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class WinSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var sharedData = systems.GetShared<SharedData>();
            var sceneData = sharedData.SceneData;
            
            var cellsFilter = world.Filter<Winner>().Inc<Taken>().End();

            var takenCells = world.GetPool<Taken>();

            foreach (var id in cellsFilter)
            {
                ref var winner = ref takenCells.Get(id);

                sceneData.UI.WinScreen.Show(true);
                sceneData.UI.WinScreen.SetWinner(winner.value);
            }
        }
    }
}