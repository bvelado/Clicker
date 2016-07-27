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
    // base data
    public GeneratorData data;

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

/// <summary>
/// Used to display resource generator with the same type
/// </summary>
[UI]
public class ResourceGeneratorContainerView : IComponent
{
    public ResourceGeneratorFamily family;
    public ViewController container;
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
    public GeneratorData data;
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

[UI]
public interface IGeneratorNumberListener
{
    void GeneratorNumberChanged();
}

[UI]
public class GeneratorNumberListenerComponent : IComponent
{
    public IGeneratorNumberListener listener;
}

[UI]
public interface IGeneratorCountListener
{
    void GeneratorCountChanged(float normalizedCount);
}

[UI]
public class GeneratorCountListenerComponent : IComponent
{
    public IGeneratorCountListener listener;
}

[Core]
public class ViewComponent : IComponent
{
    public ViewController view;
}

[Core]
public class ViewResourceComponent : IComponent
{
    public string path;
}

[Core, UI]
[CustomPrefix("flag")]
public class DestroyComponent : IComponent
{

}