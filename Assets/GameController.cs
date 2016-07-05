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

        _systems.Initialize();
    }

    Systems CreateSystems(Pool core, Pool ui)
    {
        return new Systems()
            .Add(core.CreateSystem<TickUpdateSystem>())
            .Add(core.CreateSystem< ResourceProduceSystem>());
    }

    void Update()
    {
        _systems.Execute();
    }
}
