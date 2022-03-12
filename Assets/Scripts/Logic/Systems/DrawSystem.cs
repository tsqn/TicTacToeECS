using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;

namespace TicTacToe.Logic.Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();
            var sceneData = sharedData.SceneData;

            var world = systems.GetWorld();

            var cellsFilter = world.Filter<Cell>().Exc<Taken>().End();
            var winnerFilter = world.Filter<Winner>().End();

            if (cellsFilter.GetEntitiesCount() == 0 && winnerFilter.GetEntitiesCount() == 0)
            {
                sceneData.UI.WinScreen.Show(true);
                sceneData.UI.WinScreen.SetWinner(SignType.None);
            }
        }
    }
}