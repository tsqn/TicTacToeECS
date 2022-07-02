using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Components.Tags;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class CreateSignViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();

            var filter = world.Filter<ClickedEvent>().End();

            var positions = world.GetPool<Position>();
            
            foreach (var id in filter)
            {
                ref var position = ref positions.Get(id);
                
                sharedData.MessagesBridge.OutputMessages.Enqueue(new InstantiateSignViewMessage()
                {
                    Id = id,
                    Position = position.Value,
                    SignType = sharedData.GameState.CurrentSign
                });
                
            }
        }
    }
}