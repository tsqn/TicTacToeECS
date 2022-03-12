using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;
using TicTacToe.Logic.Systems;
using TicTacToe.Unity.Wrappers;
using UnityEngine;

namespace TicTacToe.Unity
{
    internal sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField]
        public Configuration _configuration;

        [SerializeField]
        public SceneData _sceneData;

        private EcsSystems _editorSystems;
        private EcsSystems _systems;
        private EcsWorld _world;

        private void Start()
        {
            var sharedData = new SharedData
            {
                Configuration = _configuration,
                GameState = new GameState(),
                SceneData = _sceneData,
                Input = new InputDecorator(),
                Physics = new PhysicsDecorator()
            };
            _world = new EcsWorld();
            _systems = new EcsSystems(_world, sharedData);


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
                .Init();
        }

        private void Update()
        {
            _systems?.Run();

#if UNITY_EDITOR
            _editorSystems.Run();
#endif
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