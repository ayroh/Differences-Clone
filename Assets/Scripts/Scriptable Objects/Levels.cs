using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Levels")]

public class Levels : ScriptableObject
{
    public List<LevelData> levels;
}