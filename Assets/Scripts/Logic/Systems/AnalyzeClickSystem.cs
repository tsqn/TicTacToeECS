using Core;
using Interfaces;
using Leopotam.EcsLite;
using Logic.Components;
using Logic.Components.Events;

namespace Logic.Systems
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var gameState = sharedData.GameState;

            var filter = world.Filter<Cell>().Inc<ClickedEvent>().Exc<Taken>().End();

            var takenPool = world.GetPool<Taken>();
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