using UnityEngine;
using Entitas;
using Entitas.Unity.Serialization.Blueprints;
using UnityEngine.UI;
using System;

public class CreateGeneratorButtonBehaviour : MonoBehaviour, IResourceListener
{
    public Image progressBox;
    public Text buttonText; 
    public GeneratorData generatorData;
    public float cost;

    void Start()
    {
        Pools.uI.CreateEntity()
            .AddResourceListener(this);

        cost = generatorData.cost;
        buttonText.text = generatorData.label + " " + cost.ToString();
    }

    public void ButtonPressed()
    {
        Pools.core.CreateEntity()
            .AddCreateGeneratorInput(generatorData);
    }

    public void ResourceAmountChanged()
    {
        var ratio = 1 - Mathf.Min(1f, (Pools.core.resource.amount / (float)cost));
        progressBox.fillAmount = ratio;
        GetComponent<Button>().enabled = (System.Math.Abs(ratio - 0) < Mathf.Epsilon);
    }
}
