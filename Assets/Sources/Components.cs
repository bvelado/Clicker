using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[Core, SingleEntity]
public class TickComponent : IComponent
{
    public long currentTick;
}

[Core]
public class ResourceGeneratorComponent : IComponent
{
    // step amount produced
    public float step;
    // every frequency ticks
    public int frequency;
    // current count
    public int count;
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

[Core]
public class CreateGeneratorInputComponent : IComponent
{
    public int cost;
    public float step;
    public int frequency;
    public int count;
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
    void ResourceAmountChanged();
}

[UI]
public class ResourceListenerComponent : IComponent
{
    public IResourceListener listener;
}
