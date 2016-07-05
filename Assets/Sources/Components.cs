using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[Core, SingleEntity]
public class TickComponent : IComponent
{
    public long currentTick;
}


[Core, SingleEntity]
public class ResourceComponent : IComponent
{
    public float amount;
}

[Core, SingleEntity]
public class PauseComponent : IComponent { }

[Core]
public class ConsumeResourceComponent : IComponent
{
    public int amount;
}

[Core, SingleEntity]
public class LogicSystemsComponent : IComponent
{
    public Systems systems;
}

[UI]
public interface ITickListener
{
    void TickChanged();
}

[UI]
public class TickListenerComponent : IComponent
{
    public ITickListener listener;
}

[UI]
public interface IPauseListener
{
    void PauseStateChanged();
}

[UI]
public class PauseListenerComponent : IComponent
{
    public IPauseListener listener;
}

[UI]
public interface IResourceListener
{
    void ElixirAmountChanged();
}

[UI]
public class ResourceListenerComponent : IComponent
{
    public IResourceListener listener;
}
