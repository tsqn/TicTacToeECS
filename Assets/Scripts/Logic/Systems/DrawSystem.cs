using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Extensions;

namespace TicTacToe.Logic.Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsCustomInject<ILogger> _logger;
        
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();
            var sceneData = sharedData.SceneData;
            var gameState = sharedData.GameState;

            if (gameState.State != State.Playing)
            {
                return;
            }
            
            var world = systems.GetWorld();

            var cellsFilter = world.Filter<Cell>().Exc<Taken>().End();
            var winnerFilter = world.Filter<Winner>().End();

            if (cellsFilter.GetEntitiesCount() == 0 && winnerFilter.GetEntitiesCount() == 0)
            {
                sceneData.UI.WinScreen.Show(true);
                sceneData.UI.WinScreen.SetWinner(SignType.None);

                
                gameState.State = State.GameOver;
                _logger.Debug($"Draw");
            }
        }
    }
}