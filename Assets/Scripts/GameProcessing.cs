using Leopotam.Ecs;
using UnityEngine;

public sealed class GameProcessing : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        _systems?.Destroy();
        _systems = null;

        _world?.Destroy();
        _world = null;
    }
}
