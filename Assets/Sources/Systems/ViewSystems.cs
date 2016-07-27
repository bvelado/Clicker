using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

public class CreateGeneratorLineView : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group resourceGeneratorContainers;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(CoreMatcher.ResourceGenerator, CoreMatcher.ViewResource).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            Entity c = null;
            foreach (var container in resourceGeneratorContainers.GetEntities())
            {
                if (container.resourceGeneratorContainerView.family == e.resourceGenerator.data.family)
                    c = container;
            }

            if (c == null)
            {
                var go = GameObject.Instantiate(Resources.Load("Prefabs/GeneratorViewLine")) as GameObject;

                if (go)
                {
                    go.transform.SetParent(GameObject.FindGameObjectWithTag("GeneratorContainer").transform);
                }

                c = Pools.uI.CreateEntity().AddResourceGeneratorContainerView(e.resourceGenerator.data.family, go.GetComponent<GeneratorLineViewController>());

                GameObject.FindGameObjectWithTag("GeneratorContainer").GetComponent<GeneratorGlobalViewController>().AddLine(c);
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        resourceGeneratorContainers = Pools.uI.GetGroup(UIMatcher.ResourceGeneratorContainerView);
    }
}

public class CreateGeneratorView : IReactiveSystem, ISetPool {
    Pool _pool;
    Group resourceGeneratorContainers;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(CoreMatcher.ResourceGenerator, CoreMatcher.ViewResource).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            foreach (var container in resourceGeneratorContainers.GetEntities())
            {
                if (container.resourceGeneratorContainerView.family == e.resourceGenerator.data.family)
                {
                    var go = GameObject.Instantiate(Resources.Load(e.viewResource.path)) as GameObject;
                    if (go)
                    {
                        go.transform.SetParent((container.resourceGeneratorContainerView.container as GeneratorLineViewController).Container);

                        GeneratorViewController view = go.GetComponentInChildren<GeneratorViewController>();
                        view.Fill(e.resourceGenerator.data.model);

                        e.AddView(view);

                        (container.resourceGeneratorContainerView.container as GeneratorLineViewController).AddElement(e);
                        //view.gameObject.Link(e, Pools.core);
                    }
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        resourceGeneratorContainers = Pools.uI.GetGroup(UIMatcher.ResourceGeneratorContainerView);
    }
}
