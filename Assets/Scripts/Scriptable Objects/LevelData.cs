using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/LevelData")]

public class LevelData : ScriptableObject
{
    public Sprite background;
    public List<DifferenceData> differences;
    public List<SpriteData> bothLevelSprites;
}


[Serializable]
public struct DifferenceData
{
    public SpriteData difference1, difference2;
}

[Serializable]
public struct SpriteData
{
    public Sprite sprite;
    public Vector2 localPosition;
    public int orderInLayer;
}