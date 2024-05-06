using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/LevelData")]

public class LevelData : ScriptableObject
{
    public SpriteData background;
    public List<DifferenceData> differences;
    public List<SpriteData> bothLevelSprites;
}


[Serializable]
public class DifferenceData
{
    public SpriteData difference1, difference2;
}

[Serializable]
public class SpriteData
{
    public Sprite sprite;
    public Vector2 localPosition;
    public int orderInLayer;
}