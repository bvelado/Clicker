using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public interface IGeneratorLineViewController : IViewController
{
    void AddElement(Entity e);
}

public class GeneratorLineViewController : ViewController, IGeneratorLineViewController
{
    public Transform Container;

    public int ElementsPerRow = 3;
    float elementHorizontalSize;

    List<GameObject> elements = new List<GameObject>();

    Vector2 baseSizeDelta;

    void Start()
    {
        baseSizeDelta = Container.GetComponent<RectTransform>().sizeDelta;
    }

    public void AddElement(Entity e)
    {
        elements.Add(e.view.view.gameObject);

        elementHorizontalSize = e.view.view.GetComponent<RectTransform>().sizeDelta.x;

        Resize();
    }

    public void Resize()
    {
        float horizontalOffset = Container.GetComponent<HorizontalLayoutGroup>().padding.left + (Container.GetComponent<HorizontalLayoutGroup>().spacing * elements.Count) + Container.GetComponent<HorizontalLayoutGroup>().padding.right;
        //print("Horizontal offset : " + horizontalOffset + " && element horizontal size : " + elementHorizontalSize);
        Container.GetComponent<RectTransform>().sizeDelta = new Vector2((elements.Count * elementHorizontalSize) + horizontalOffset, baseSizeDelta.y);
    }
}