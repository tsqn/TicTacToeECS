using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Extensions;

namespace TicTacToe.Logic.Systems
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsCustomInject<ILogger> _logger;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var sceneData = sharedData.SceneData;

            var cellsFilter = world.Filter<Winner>().Inc<Sign>().End();
            var winnerPool = world.GetPool<Winner>();

            var takenCells = world.GetPool<Sign>();

            foreach (var id in cellsFilter)
            {
                ref var winner = ref takenCells.Get(id);

                sceneData.UI.WinScreen.Show(true);
                sceneData.UI.WinScreen.SetWinner(winner.Type);
                
                winnerPool.Del(id);
                
                sharedData.GameState.State = State.GameOver;
                _logger.Debug($"{winner.Type} Wins!");
            }
        }
    }
}