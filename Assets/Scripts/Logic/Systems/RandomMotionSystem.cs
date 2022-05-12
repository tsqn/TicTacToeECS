using System;
using Leopotam.EcsLite;
using TicTacToe.Logic.Components;

namespace TicTacToe.Logic.Systems
{
    public class RandomMotionSystem : IEcsRunSystem
    {
        private Random _random;

        public void Run(EcsSystems systems)
        {

            _random = new Random();
            
            var world = systems.GetWorld();

            var filter = world.Filter<Position>().End();
            
            var positionComponents = world.GetPool<Position>();

            foreach (var id in filter)
            {
                ref var position = ref positionComponents.Get(id);

                position.Value.X += _random.Next(-1, 1);
                position.Value.Y += _random.Next(-1, 1);
            }
        }
    }
}