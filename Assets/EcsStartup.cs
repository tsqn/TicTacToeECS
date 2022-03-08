using Components;
using Leopotam.Ecs;
using Systems;
using Unity.VisualScripting;
using UnityEngine;

sealed class EcsStartup : MonoBehaviour {
    EcsWorld _world;
    EcsSystems _systems;
    public Configuration Configuration;
    public SceneData SceneData;
    void Start () {
        // void can be switched to IEnumerator for support coroutines.
            
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

        var gameState = new GameState();
        
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
            .OneFrame<UpdateCameraEvent>()
            .OneFrame<Clicked>()
            .OneFrame<CheckWinEvent>()
            .Inject(gameState)
            .Inject(Configuration)
            .Inject(SceneData)
            .Init ();
    }

    void Update () {
        _systems?.Run ();
    }

    void OnDestroy () {
        if (_systems != null) {
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}