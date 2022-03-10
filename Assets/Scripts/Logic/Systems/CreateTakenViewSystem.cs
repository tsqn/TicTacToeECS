using System;
using Core;
using Interfaces;
using Leopotam.EcsLite;
using Logic.Components;
using Logic.Components.Refs;

namespace Logic.Systems
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;


            var filter = world.Filter<Taken>().Inc<CellViewRef>().Exc<TakenViewRef>().End();

            var takenCells = world.GetPool<Taken>();
            var cellViewRefs = world.GetPool<CellViewRef>();
            var takenViewRefs = world.GetPool<TakenViewRef>();

            foreach (var id in filter)
            {
                ref var cellViewRef = ref cellViewRefs.Get(id);
                var position = cellViewRef.View.Position;
                ref var takenComponent = ref takenCells.Get(id);
                var taken = takenComponent.Type;

                var sigView = taken switch
                {
                    SignType.Cross => configuration.CrossView,
                    SignType.Ring => configuration.RingView,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var instance =  sigView.Instantiate(position);
                ref var takenViewRef = ref takenViewRefs.Add(id);
                takenViewRef.View = (ISignView)instance;
            }
        }
    }
}