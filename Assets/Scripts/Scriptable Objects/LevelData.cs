using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/LevelData")]

public class LevelData : ScriptableObject
{
    public Sprite background;
    public List<DifferenceData> differences;
}


[Serializable]
public struct DifferenceData
{
    public Sprite difference1, difference2;
    public Vector2 localPosition;
    public int orderInLayer;
}