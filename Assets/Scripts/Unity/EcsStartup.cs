using Leopotam.EcsLite;
using TicTacToe.Logic.Systems;
using TicTacToe.Unity.Wrappers;
using UnityEngine;

#if UNITY_EDITOR
using Leopotam.EcsLite.UnityEditor;
#endif

namespace TicTacToe.Unity
{
    internal sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField]
        public Configuration _configuration;

        [SerializeField]
        public SceneData _sceneData;

        private EcsSystems _editorSystems;
        private SharedData _sharedData;

        private Synchronizer _synchronizer;
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
                Server = new Server.Server()
            };
            _world = new EcsWorld();
            _systems = new EcsSystems(_world, _sharedData);

            _synchronizer = Synchronizer.Instance;

            EditorSystemsInit();

            _systems
                .Add(new InitializeFieldSystem())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                .Add(new ControlSystem())
                .Add(new AnalyzeClickSystem())
                .Add(new CreateTakenViewSystem())
                .Add(new CheckWinSystem())
                .Add(new WinSystem())
                .Add(new DrawSystem())
                // .Add(new RandomMotionSystem())
                .Add(new SerializationSystem())
                .Add(new SyncSystem())
                .Init();
        }

        private void Update()
        {
            _systems?.Run();

#if UNITY_EDITOR
            _editorSystems.Run();
#endif

            _synchronizer.Sync();
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

            _synchronizer?.Dispose();
            _sharedData?.Dispose();
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