using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine.UI;

public interface IGeneratorGlobalViewController : IViewController
{

}

public class GeneratorGlobalViewController : ViewController, IGeneratorGlobalViewController {

    public Transform Container;

    List<GameObject> elements = new List<GameObject>();
    
    float elementVerticalSize;

    Vector2 baseSizeDelta;

    void Start()
    {
        baseSizeDelta = Container.GetComponent<RectTransform>().sizeDelta;
    }

    public void AddLine(Entity e)
    {
        elements.Add(e.resourceGeneratorContainerView.container.gameObject);

        elementVerticalSize = e.resourceGeneratorContainerView.container.GetComponent<RectTransform>().sizeDelta.y;

        Resize();
    }

    public void Resize()
    {
        float verticalOffset = Container.GetComponent<VerticalLayoutGroup>().padding.top + (Container.GetComponent<VerticalLayoutGroup>().spacing * elements.Count) + Container.GetComponent<VerticalLayoutGroup>().padding.bottom;
        print("Vertical offset : " + verticalOffset + " && element vertical size : " + elementVerticalSize);
        Container.GetComponent<RectTransform>().sizeDelta = new Vector2(baseSizeDelta.x, (elements.Count * elementVerticalSize) + verticalOffset);
    }

}
