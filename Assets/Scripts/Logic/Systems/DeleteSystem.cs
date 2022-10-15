using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Tags;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class DeleteSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var sharedData = systems.GetShared<ISharedData>();
            var filter = world.Filter<Sign>().Inc<DeleteTag>().End();

            var signCells = world.GetPool<Sign>();
            var deleteTags = world.GetPool<DeleteTag>();

            foreach (var id in filter)
            {
                sharedData.MessagesBridge.OutputMessages.Enqueue(new DeleteSignMessage()
                {
                    Id = id
                });
                signCells.Del(id);
                deleteTags.Del(id);
            }
        }
    }
}