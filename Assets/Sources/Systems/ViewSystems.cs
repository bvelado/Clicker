using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

public class CreateGeneratorView : IReactiveSystem {
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
            var go = GameObject.Instantiate(Resources.Load(e.viewResource.path)) as GameObject;
            if (go)
            {   
                go.transform.SetParent(GameObject.FindGameObjectWithTag("GeneratorContainer").transform);

                GeneratorViewController view = go.GetComponentInChildren<GeneratorViewController>();
                view.Fill(e.resourceGenerator.data.model);

                e.AddView(view);

                //view.gameObject.Link(e, Pools.core);
            }
        }
    }
}
