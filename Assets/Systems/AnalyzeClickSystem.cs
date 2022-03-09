using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<SharedData>();
            var gameState = sharedData.GameState;

            var filter = world.Filter<Cell>().Inc<ClickedEvent>().Exc<Taken>().End();

            var takenPool = world.GetPool<Taken>();
            var checkWinEventPool = world.GetPool<CheckWinEvent>();
            var clickedEventPool = world.GetPool<ClickedEvent>();

            foreach (var id in filter)
            {
                ref var takenCell = ref takenPool.Add(id);

                takenCell.value = gameState.CurrentSign;

                gameState.CurrentSign = gameState.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;

                checkWinEventPool.Add(id);
                clickedEventPool.Del(id);
                
            }
        }
    }
}