using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components.Events;

namespace TicTacToe.Logic.Systems
{
    public class MessagesSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();

            var world = systems.GetWorld();

            var eventsQueue = sharedData.EventsManager.InputEvents;

            while (eventsQueue.TryDequeue(out var result))
            {
                switch (result)
                {
                    case RestartMessage:
                    {
                        var restartEvents = world.GetPool<RestartMessage>();
                        restartEvents.Add(world.NewEntity());
                        break;
                    }
                }
            }
        }
    }
}