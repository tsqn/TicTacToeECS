using Leopotam.EcsLite;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Refs;
using TicTacToe.Logic.Components.Tags;

namespace TicTacToe.Logic.Systems
{
    public class DeleteSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var filter = world.Filter<Sign>().Inc<SignViewRef>().Inc<DeleteTag>().End();

            var signCells = world.GetPool<Sign>();
            var signViewRefs = world.GetPool<SignViewRef>();
            var deleteTags = world.GetPool<DeleteTag>();

            foreach (var id in filter)
            {
                ref var signViewRef = ref signViewRefs.Get(id);

                signViewRef.View.Destroy();
                signCells.Del(id);
                signViewRefs.Del(id);
                deleteTags.Del(id);
            }
        }
    }
}