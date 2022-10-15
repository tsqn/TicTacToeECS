using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;

namespace TicTacToe.Logic.Systems
{
    public class InitializeFieldSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();
            var configuration = sharedData.Configuration;
            var gameState = sharedData.GameState;

            var cellComponents = world.GetPool<Cell>();
            var positionComponents = world.GetPool<CellPosition>();
            

            for (var x = 0; x < configuration.LevelWidth; x++)
            {
                for (var y = 0; y < configuration.LevelHeight; y++)
                {
                    var newCell = world.NewEntity();

                    cellComponents.Add(newCell);
                    ref var position = ref positionComponents.Add(newCell);
                    position.Value = new Vector2(x, y);

                    gameState.Cells[position.Value] = newCell;
                }
            }

            var eventPool = world.GetPool<UpdateCameraEvent>();
            eventPool.Add(world.NewEntity());
        }
    }
}