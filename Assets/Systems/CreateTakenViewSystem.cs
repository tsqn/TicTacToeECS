using System;
using Components;
using Leopotam.EcsLite;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Systems
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<SharedData>();
            var configuration = sharedData.Configuration;

            
            var filter = world.Filter<Taken>().Inc<CellViewRef>().Exc<TakenViewRef>().End();

            var takenCells = world.GetPool<Taken>();
            var cellViewRefs = world.GetPool<CellViewRef>();
            var takenViewRefs = world.GetPool<TakenViewRef>();

            foreach (var id in filter)
            {
                ref var cellViewRef = ref cellViewRefs.Get(id);
                var position = cellViewRef.View.transform.position;
                ref var takenComponent = ref takenCells.Get(id);
                var taken = takenComponent.value;

                SignView sigView = null;
                switch (taken)
                {
                    case SignType.None:
                        break;
                    case SignType.Cross:
                        sigView = configuration.CrossView;
                        break;
                    case SignType.Ring:
                        sigView = configuration.RingView;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var instance = Object.Instantiate(sigView, position, Quaternion.identity);
                ref var takenViewRef = ref takenViewRefs.Add(id);
                takenViewRef.View = instance;
            }
        }
    }
}