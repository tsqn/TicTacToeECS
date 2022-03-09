using Leopotam.EcsLite;
using TicTacToe.Components;
using TicTacToe.Components.Events;
using TicTacToe.Unity;
using UnityEngine;

namespace TicTacToe.Systems
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<SharedData>();
            var configuration = sharedData.Configuration;
            var gameState = sharedData.GameState;

            var cellComponents = world.GetPool<Cell>();
            var positionComponents = world.GetPool<Position>();

            for (var x = 0; x < configuration.LevelWidth; x++)
            {
                for (var y = 0; y < configuration.LevelHeight; y++)
                {
                    var newCell = world.NewEntity();

                    cellComponents.Add(newCell);
                    ref var position = ref positionComponents.Add(newCell);
                    position.Value = new Vector2Int(x, y);


                    gameState.Cells[position.Value] = newCell;
                }
            }

            var eventPool = world.GetPool<UpdateCameraEvent>();
            eventPool.Add(world.NewEntity());
        }
    }
}