using Leopotam.Ecs;
using UnityEngine;
using Settings;

public sealed class GameProcessing : MonoBehaviour
{
    [SerializeField] private SettingsProvider _settingsProvider;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
    }

    private void Start()
    {
        AddSystems();

        _systems.Init();
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

    private void AddSystems()
    {
        _systems
            .Inject(_settingsProvider);
    }
}
