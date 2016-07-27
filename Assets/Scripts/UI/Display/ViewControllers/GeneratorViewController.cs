using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public interface IGeneratorViewController : IViewController
{
    void Fill(Sprite sprite);
}

public class GeneratorViewController : ViewController, IGeneratorViewController, IGeneratorCountListener
{
    public Image Model;
    public Image Progress;

    public void Fill(Sprite model)
    {
        Model.overrideSprite = model;
    }

    public void GeneratorCountChanged(float normalizedCount)
    {
        Progress.fillAmount = normalizedCount;
    }
}
