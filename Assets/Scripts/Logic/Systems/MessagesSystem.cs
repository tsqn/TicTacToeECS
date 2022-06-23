using Leopotam.EcsLite;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class MessagesSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var sharedData = systems.GetShared<ISharedData>();

            var world = systems.GetWorld();

            while (sharedData.EventsManager.InputMessages.TryDequeue(out var result))
            {
                switch (result)
                {
                    case RestartMessage:
                    {
                        var restartEvents = world.GetPool<RestartMessage>();
                        restartEvents.Add(world.NewEntity());
                        break;
                    }
                    case ClickedCellViewMessage message:
                    {
                        var clickedPool = world.GetPool<ClickedEvent>();
                        var takenPool = world.GetPool<Sign>();

                        if (!takenPool.Has(message.Entity))
                        {
                            clickedPool.Add(message.Entity);
                        }
                        break;
                    }
                }
            }
        }
    }
}