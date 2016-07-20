using UnityEngine;
using Entitas;
using Entitas.Unity.Serialization.Blueprints;
using UnityEngine.UI;

public class CreateGeneratorButtonBehaviour : MonoBehaviour, IResourceListener
{
    public Image progressBox; 
    public GeneratorData generatorData;
    public float baseCost;

    void Start()
    {
        Pools.uI.CreateEntity()
            .AddResourceListener(this);
    }

    public void ButtonPressed()
    {
        Pools.core.CreateEntity()
            .AddCreateGeneratorInput(generatorData);
    }

    public void ResourceAmountChanged()
    {
        var ratio = 1 - Mathf.Min(1f, (Pools.core.resource.amount / (float)baseCost));
        progressBox.fillAmount = ratio;
        GetComponent<Button>().enabled = (System.Math.Abs(ratio - 0) < Mathf.Epsilon);
    }
}
