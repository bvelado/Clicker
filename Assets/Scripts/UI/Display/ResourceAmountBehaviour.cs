using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ResourceAmountBehaviour : MonoBehaviour, IResourceListener {

    void Start()
    {
        Pools.uI.CreateEntity().AddResourceListener(this);
    }

    public void ResourceAmountChanged()
    {
        var label = GetComponent<Text>();
        label.text = ((int)Pools.core.resource.amount).ToString();
        label.color = System.Math.Abs(Pools.core.resource.amount - Config.RESOURCE_CAPACITY) < Mathf.Epsilon ? Color.red : Color.black;
    }
}
