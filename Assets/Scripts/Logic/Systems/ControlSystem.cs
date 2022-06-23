using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class ControlSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();

            if (sharedData.GameState.State != State.Playing)
            {
                return;
            }

            if (sharedData.Input.GetMouseButtonDown(0))
            {
                sharedData.EventsManager.OutputMessages.Enqueue(new RequestScreenPointToRayMessage()
                {
                    Position = sharedData.Input.MousePosition
                });;
              
            }
        }
    }
}