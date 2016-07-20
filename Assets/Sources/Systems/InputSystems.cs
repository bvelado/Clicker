using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceConsumeSystem : IReactiveSystem, ISetPool, IEnsureComponents
{
    Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.consumeResource.amount > _pool.resource.amount)
            {
                UnityEngine.Debug.LogError("Consume more than produced. Should not happen");
            }
            var newAmount = Math.Max(0, _pool.resource.amount - entity.consumeResource.amount);
            _pool.ReplaceResource(newAmount);
        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.ConsumeResource.OnEntityAdded(); } }

    public void SetPool(Pool pool) { _pool = pool; }

    public IMatcher ensureComponents { get { return CoreMatcher.ConsumeResource; } }
}

public class ResourceConsumeCleanupSystem : IReactiveSystem, ISetPool, IEnsureComponents
{
    Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            _pool.DestroyEntity(entity);
        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.ConsumeResource.OnEntityAdded(); } }

    public void SetPool(Pool pool) { _pool = pool; }

    public IMatcher ensureComponents { get { return CoreMatcher.ConsumeResource; } }
}

public class CreateGeneratorSystem : IReactiveSystem, ISetPool, IEnsureComponents
{
    Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.createGeneratorInput.data.cost > _pool.resource.amount)
            {
                UnityEngine.Debug.LogError("Not enough money to buy this generator");
            }
            var newAmount = Math.Max(0, _pool.resource.amount - entity.createGeneratorInput.data.cost);
            _pool.ReplaceResource(newAmount);

            Entity generator = _pool.CreateEntity()
                .AddResourceGenerator(entity.createGeneratorInput.data, entity.createGeneratorInput.data.step, entity.createGeneratorInput.data.frequency, 0);

            if (entity.createGeneratorInput.data.model != null)
                generator.AddViewResource("Prefabs/Generator");

        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.CreateGeneratorInput.OnEntityAdded(); } }

    public void SetPool(Pool pool) { _pool = pool; }

    public IMatcher ensureComponents { get { return CoreMatcher.CreateGeneratorInput; } }
}

public class CreateGeneratorCleanupSystem : IReactiveSystem, ISetPool, IEnsureComponents
{
    Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            entity.FlagDestroy(true);
        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.CreateGeneratorInput.OnEntityAdded(); } }

    public void SetPool(Pool pool) { _pool = pool; }

    public IMatcher ensureComponents { get { return CoreMatcher.CreateGeneratorInput; } }
}