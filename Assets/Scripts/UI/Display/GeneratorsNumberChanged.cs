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

        Pools.uI.CreateEntity().AddGeneratorNumberListener(this);
    }

    public void GeneratorNumberChanged()
    {

    }
}
