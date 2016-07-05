using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;
using System;

public class TickUpdateSystem : IInitializeSystem, IExecuteSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool) { _pool = pool; }

    public void Initialize() { _pool.ReplaceTick(0); }

    public void Execute()
    {
        if (!_pool.isPause)
        {
            _pool.ReplaceTick(_pool.tick.currentTick + 1);
        }
    }
}


public class ResourceProduceSystem : IReactiveSystem, ISetPool, IInitializeSystem
{
    Pool _pool;
    int count = 0;

    public TriggerOnEvent trigger { get { return CoreMatcher.Tick.OnEntityAdded(); } }

    public void SetPool(Pool pool) { _pool = pool; }

    public void Initialize()
    {
        _pool.ReplaceResource(0);
    }

    public void Execute(List<Entity> entities)
    {
        if (count == 0)
        {
            var newAmount = Math.Min(Config.RESOURCE_CAPACITY, _pool.resource.amount + Config.RESOURCE_PRODUCTION_STEP);
            _pool.ReplaceResource(newAmount);
        }
        count = ((count + 1) % Config.RESOURCE_PRODUCTION_FREQUENCY);
    }
}