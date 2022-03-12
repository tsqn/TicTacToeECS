using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;

namespace TicTacToe.Logic.Systems
{
    public class WinSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var sceneData = sharedData.SceneData;

            var cellsFilter = world.Filter<Winner>().Inc<Taken>().End();

            var takenCells = world.GetPool<Taken>();

            foreach (var id in cellsFilter)
            {
                ref var winner = ref takenCells.Get(id);

                sceneData.UI.WinScreen.Show(true);
                sceneData.UI.WinScreen.SetWinner(winner.Type);
            }
        }
    }
}