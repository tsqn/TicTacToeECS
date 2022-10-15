using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TicTacToe.Logic.Systems;
using TicTacToe.Unity.Resolvers;
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

        private MessagesBridge _messagesBridge;

        private IEcsSystems _editorSystems;

        private InputManager _inputManager;
        private MessageResolver _messageResolver;
        private SharedData _sharedData;
        private IEcsSystems _systems;
        private EcsWorld _world;

        private void Start()
        {
            _messagesBridge = MessagesBridge.Instance;
            _inputManager = new InputManager(_messagesBridge);

            _sharedData = new SharedData
            {
                Configuration = _configuration,
                GameState = new GameState(),
                MessagesBridge = _messagesBridge
            };
            
            _messageResolver = new MessageResolver
            {
                MessagesBridge = _messagesBridge,
                WinScreen = _sceneData.UIController.WinScreen,
                Configuration = _configuration
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
                .Add(new MessagesSystem())
                .Add(new InitializeFieldSystem())
                .Add(new CreateCellViewSystem())
                .Add(new CreateSignViewSystem())
                .Add(new SetCameraSystem())
                .Add(new AnalyzeClickSystem())
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
            _inputManager.Update();
            _messageResolver.Update();
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
            // create separate IEcsSystems group for editor systems only.
            _editorSystems = new EcsSystems(_world);
            _editorSystems
                .Add(new EcsWorldDebugSystem())
                .Init();
#endif
        }
    }
}