using System.Collections.Generic;
using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Logic.Components;

namespace TicTacToe.Logic.Systems
{
    public class SerializationSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<Cell>().Inc<Position>().End();
            var positions = world.GetPool<Position>();
            var worldStates = world.GetPool<WorldState>();


            var result = new Dictionary<int, Vector3>();
            foreach (var id in filter)
            {
                result.Add(id, positions.Get(id).Value);
            }

            var worldStateEntity = world.NewEntity();
            ref var x = ref worldStates.Add(worldStateEntity);
            x.State = result;
        }
    }
}