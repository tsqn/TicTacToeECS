using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TicTacToe.Core;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Messages;

namespace TicTacToe.Logic.Systems
{
    public class GameOverSystem : IEcsRunSystem
    {
        private EcsCustomInject<ILogger> _logger;

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();

            var sharedData = systems.GetShared<ISharedData>();

            var gameOverEvent = world.Filter<GameOverMessage>().End();

            if (gameOverEvent.GetEntitiesCount() == 0)
            {
                return;
            }

            var gameOverEntity = gameOverEvent.GetRawEntities()[0];
            sharedData.MessagesBridge.OutputMessages.Enqueue(new GameOverMessage()
            {
                Result = world.GetPool<GameOverMessage>().Get(gameOverEntity).Result 
            });
                
            sharedData.GameState.State = State.GameOver;
            
            world.GetPool<GameOverMessage>().Del(gameOverEntity);
        }
    }
}