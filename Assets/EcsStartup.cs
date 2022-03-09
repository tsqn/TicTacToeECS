using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;
using Systems;
using UnityEngine;

internal sealed class EcsStartup : MonoBehaviour
{
    public Configuration Configuration;
    public SceneData SceneData;
    private EcsSystems _systems;
    private EcsWorld _world;
    private EcsSystems _editorSystems;

    private void Start()
    {
        // void can be switched to IEnumerator for support coroutines.

        var sharedData = new SharedData
        {
            Configuration = Configuration,
            GameState = new GameState(),
            SceneData = SceneData
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
}