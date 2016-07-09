using Entitas;
using System.Collections.Generic;

public class NotifyTickListenersSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group listeners;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in listeners.GetEntities())
        {
            entity.tickListener.listener.TickChanged();
        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.Tick.OnEntityAddedOrRemoved(); } }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        listeners = Pools.uI.GetGroup(UIMatcher.TickListener);
    }
}

public class NotifyPauseListenersSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group listeners;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in listeners.GetEntities())
        {
            entity.pauseListener.listener.PauseStateChanged();
        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.Pause.OnEntityAddedOrRemoved(); } }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        listeners = Pools.uI.GetGroup(UIMatcher.PauseListener);
    }
}

public class NotifyResourceListenersSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group listeners;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in listeners.GetEntities())
        {
            entity.resourceListener.listener.ResourceAmountChanged();
        }
    }

    public TriggerOnEvent trigger { get { return CoreMatcher.Resource.OnEntityAddedOrRemoved(); } }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        listeners = Pools.uI.GetGroup(UIMatcher.ResourceListener);
    }
}