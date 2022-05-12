using System;
using System.Security.Cryptography;
using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;

namespace TicTacToe.Logic.Systems
{
    public class SyncSystem : IEcsRunSystem
    {

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var shared = systems.GetShared<ISharedData>();
            var filter = world.Filter<WorldState>().End();
            var worldStates = world.GetPool<WorldState>();

            foreach (var id in filter)
            {
                ref var state = ref worldStates.Get(id);
                
                shared.Server.SendWorldStateMessage(state);

                worldStates.Del(id);
            }
        }
    }
}