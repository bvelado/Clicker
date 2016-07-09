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

public class GeneratorProduceSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group _generators;
    int count = 0;

    public TriggerOnEvent trigger { get { return CoreMatcher.Tick.OnEntityAdded(); } }

    public void SetPool(Pool pool) {
        _pool = pool;
        _generators = Pools.core.GetGroup(CoreMatcher.ResourceGenerator);
    }
    
    public void Execute(List<Entity> entities)
    {
        foreach(var e in _generators.GetEntities())
        {
            if (e.resourceGenerator.count == 0)
            {
                var newAmount = Math.Min(Config.RESOURCE_CAPACITY, _pool.resource.amount + e.resourceGenerator.step);
                _pool.ReplaceResource(newAmount);
            }
            e.resourceGenerator.count = ((e.resourceGenerator.count + 1) % e.resourceGenerator.frequency);
        }
    }
}