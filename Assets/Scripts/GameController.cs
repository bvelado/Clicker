using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    Systems _systems;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        _systems = CreateSystems(Pools.core, Pools.uI);

        Pools.core.ReplaceResource(0);
        Pools.core.CreateEntity().AddResourceGenerator(Config.BASE_GENERATOR_PRODUCTION_STEP, Config.BASE_GENERATOR_PRODUCTION_FREQUENCY, 0);

        _systems.Initialize();
    }

    Systems CreateSystems(Pool core, Pool ui)
    {
        return new Feature("Systems")

            // Notify listeners
            .Add(core.CreateSystem<NotifyTickListenersSystem>())
            .Add(core.CreateSystem<NotifyPauseListenersSystem>())
            .Add(core.CreateSystem<NotifyResourceListenersSystem>())

            //Tick
            .Add(core.CreateSystem<TickUpdateSystem>())

            // Resource
            .Add(core.CreateSystem<GeneratorProduceSystem>())

            // Input
            .Add(core.CreateSystem<ResourceConsumeSystem>())
            .Add(core.CreateSystem<CreateGeneratorSystem>())

            // Cleanup
            .Add(core.CreateSystem<ResourceConsumeCleanupSystem>());
    }

    void Update()
    {
        _systems.Execute();
    }
}
