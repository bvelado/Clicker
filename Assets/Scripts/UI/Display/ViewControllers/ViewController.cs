using System;
using UnityEngine;

public interface IViewController
{
    void Hide();
}

public class ViewController : MonoBehaviour, IViewController
{
    public virtual void Hide()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}