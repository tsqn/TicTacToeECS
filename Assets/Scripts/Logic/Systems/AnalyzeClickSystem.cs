using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;

namespace TicTacToe.Logic.Systems
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var gameState = sharedData.GameState;

            var filter = world.Filter<Cell>().Inc<ClickedEvent>().Exc<Sign>().End();

            var takenPool = world.GetPool<Sign>();
            var checkWinEventPool = world.GetPool<CheckWinEvent>();
            var clickedEventPool = world.GetPool<ClickedEvent>();

            foreach (var id in filter)
            {
                ref var takenCell = ref takenPool.Add(id);

                takenCell.Type = gameState.CurrentSign;

                gameState.CurrentSign = gameState.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;

                checkWinEventPool.Add(id);
                clickedEventPool.Del(id);
            }
        }
    }
}