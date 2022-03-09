using Leopotam.EcsLite;
using TicTacToe.Components;
using TicTacToe.Components.Events;
using TicTacToe.Unity;
using TicTacToe.Unity.Views;
using UnityEngine;

namespace TicTacToe.Systems
{
    internal class ControlSystem : IEcsRunSystem
    {
        private SceneData _sceneData;

        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<SharedData>();
            var sceneData = sharedData.SceneData;

            if (Input.GetMouseButtonDown(0))
            {
                var camera = sceneData.Camera;

                var ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = hitInfo.collider.GetComponent<CellView>();

                    if (cellView)
                    {
                        var world = systems.GetWorld();
                        var clickedPool = world.GetPool<ClickedEvent>();
                        var takenPool = world.GetPool<Taken>();

                        if (!takenPool.Has(cellView.Entity))
                        {
                            clickedPool.Add(cellView.Entity);
                        }
                    }
                }
            }
        }
    }
}