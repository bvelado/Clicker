using UnityEngine;
using System.Collections;
using System;
using Entitas;

[RequireComponent(typeof(RectTransform))]
public class GeneratorsNumberChanged : MonoBehaviour, IGeneratorNumberListener
{
    RectTransform rectTransform;
    int numberOfElementsPerRow = 3;
    Vector2 baseSizeDelta;

    Group baseGeneratorsGroup;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        baseSizeDelta = rectTransform.sizeDelta;

        baseGeneratorsGroup = Pools.core.GetGroup(CoreMatcher.ResourceGenerator);

        Pools.uI.CreateEntity().AddGeneratorNumberListener(this);
    }

    public void GeneratorNumberChanged()
    {
        Debug.Log("Number of generators changed, now : " + baseGeneratorsGroup.count);
        rectTransform.sizeDelta = new Vector2(baseSizeDelta.x, (baseGeneratorsGroup.count + numberOfElementsPerRow - 1) / numberOfElementsPerRow * baseSizeDelta.y);
    }
}
