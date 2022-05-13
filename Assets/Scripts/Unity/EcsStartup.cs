using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TicTacToe.Logic.Systems;
using TicTacToe.Unity.Decorators;
using UnityEngine;
#if UNITY_EDITOR
using Leopotam.EcsLite.UnityEditor;
#endif

namespace TicTacToe.Unity
{
    internal sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField]
        private Configuration _configuration;

        [SerializeField]
        private SceneData _sceneData;

        [SerializeField]
        private EventsManager _eventsManager;

        private EcsSystems _editorSystems;

        private EventsResolver _eventsResolver;
        private SharedData _sharedData;
        private EcsSystems _systems;
        private EcsWorld _world;

        private void Start()
        {
            _sharedData = new SharedData
            {
                Configuration = _configuration,
                GameState = new GameState(),
                SceneData = _sceneData,
                Input = new InputDecorator(),
                Physics = new PhysicsDecorator(),
                EventsManager = _eventsManager
            };

            _eventsResolver = new EventsResolver
            {
                EventsManager = _eventsManager,
                WinScreen = _sceneData.UI.WinScreen
            };

            _world = new EcsWorld();
            _systems = new EcsSystems(_world, _sharedData);

            EditorSystemsInit();

            var logger = new Logger
            {
                WriteToUnityConsole = true,
                WriteDebugToUnityConsole = true,
                WriteErrorsToUnityConsole = true,
                WriteWarningToUnityConsole = true
            };

            _systems
                .Add(new InitializeFieldSystem())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                .Add(new ControlSystem())
                .Add(new AnalyzeClickSystem())
                .Add(new CreateSignViewSystem())
                .Add(new CheckWinSystem())
                .Add(new GameOverSystem())
                .Add(new RestartSystem())
                .Add(new DeleteSystem())
                .Inject(logger)
                .Init();
        }

        private void Update()
        {
            _systems?.Run();

#if UNITY_EDITOR
            _editorSystems.Run();
#endif
            _eventsResolver.Update();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }

        private void EditorSystemsInit()
        {
#if UNITY_EDITOR
            // create separate EcsSystems group for editor systems only.
            _editorSystems = new EcsSystems(_world);
            _editorSystems
                .Add(new EcsWorldDebugSystem())
                .Init();
#endif
        }
    }
}