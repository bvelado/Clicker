using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

public class DestroySystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AnyOf(CoreMatcher.Destroy, UIMatcher.Destroy).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            _pool.DestroyEntity(e);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
