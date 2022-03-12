using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;

namespace TicTacToe.Logic.Systems
{
    public class ControlSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();
            var sceneData = sharedData.SceneData;

            if (sharedData.Input.GetMouseButtonDown(0))
            {
                var camera = sceneData.Camera;

                var ray = camera.ScreenPointToRay(sharedData.Input.MousePosition);

                if (sharedData.Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = (ICellView)hitInfo.Collider.GetComponent<ICellView>();

                    if (cellView != null)
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