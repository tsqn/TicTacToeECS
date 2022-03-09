using System;
using Leopotam.EcsLite;
using TicTacToe.Components;
using TicTacToe.Components.Refs;
using TicTacToe.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TicTacToe.Systems
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
                var taken = takenComponent.Type;

                var sigView = taken switch
                {
                    SignType.Cross => configuration.CrossView,
                    SignType.Ring => configuration.RingView,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var instance = Object.Instantiate(sigView, position, Quaternion.identity);
                ref var takenViewRef = ref takenViewRefs.Add(id);
                takenViewRef.View = instance;
            }
        }
    }
}