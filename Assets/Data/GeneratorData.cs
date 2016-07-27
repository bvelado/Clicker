using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Data/Generators/BaseGenerator")]
public class GeneratorData : ScriptableObject {
    public int cost;
    public float step;
    public int frequency;
    public Sprite model;
    public string label;
    public ResourceGeneratorFamily family;
}
