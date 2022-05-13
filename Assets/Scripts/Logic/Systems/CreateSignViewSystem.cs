using System;
using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Refs;

namespace TicTacToe.Logic.Systems
{
    public class CreateSignViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;


            var filter = world.Filter<Sign>().Inc<CellViewRef>().Exc<SignViewRef>().End();

            var signed = world.GetPool<Sign>();
            var cellViewRefs = world.GetPool<CellViewRef>();
            var takenViewRefs = world.GetPool<SignViewRef>();

            foreach (var id in filter)
            {
                ref var cellViewRef = ref cellViewRefs.Get(id);
                var position = cellViewRef.View.Position;
                ref var takenComponent = ref signed.Get(id);
                var taken = takenComponent.Type;

                var sigView = taken switch
                {
                    SignType.Cross => configuration.CrossView,
                    SignType.Ring => configuration.RingView,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var instance = sigView.Instantiate(id, position);
                ref var takenViewRef = ref takenViewRefs.Add(id);
                takenViewRef.View = (ISignView) instance;
            }
        }
    }
}