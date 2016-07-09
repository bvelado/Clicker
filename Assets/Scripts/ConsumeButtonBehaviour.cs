using System;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeButtonBehaviour : MonoBehaviour, IPauseListener, IResourceListener {
    public Text label;
    public Image progressBox;
    public int consumptionAmmount;

    float maxHeight;

    void Awake()
    {
        label.text = consumptionAmmount.ToString();

        Pools.uI.CreateEntity().AddPauseListener(this).AddResourceListener(this);
    }

    public void PauseStateChanged()
    {
        GetComponent<Button>().enabled = !Pools.uI.isPause;
    }

    public void ButtonPressed()
    {
        if (Pools.core.isPause) return;
        Pools.core.CreateEntity().AddConsumeResource(consumptionAmmount);
    }

    public void ResourceAmountChanged()
    {
        var ratio = 1 - Mathf.Min(1f, (Pools.core.resource.amount / (float)consumptionAmmount));
        progressBox.fillAmount = ratio;
        GetComponent<Button>().enabled = (System.Math.Abs(ratio - 0) < Mathf.Epsilon);
    }
}
