using Pool;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/PoolObjects")]
public class PoolObjects : ScriptableObject
{
    [SerializeField] private DifferenceObject differenceObject;
    [SerializeField] private SpriteObject spriteObject;

    public Dictionary<IPoolable, int> GetIPoolables()
    {
        return new Dictionary<IPoolable, int>
        {
            { differenceObject, 20 },
            { spriteObject, 8 }
        };
    }
}