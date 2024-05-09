using Objects;
using Pool;
using System;
using System.Collections.Generic;
using UnityEngine;
using LifeManage;
using ScoreManage;

[CreateAssetMenu(menuName = "Scriptables/PoolObjects")]
public class PoolObjects : ScriptableObject
{
    [SerializeField] private DifferenceObject differenceObject;
    [SerializeField] private SpriteObject spriteObject;
    [SerializeField] private CorrectCheck correctCheck;
    [SerializeField] private Life life;
    [SerializeField] private Score score;
    [SerializeField] private BackgroundObject backgroundObject;
    [SerializeField] private FoundParticle foundParticle;

    public Dictionary<IPoolable, int> GetIPoolables()
    {
        return new Dictionary<IPoolable, int>
        {
            { differenceObject, 20 },
            { spriteObject, 8 },
            { correctCheck, 20 },
            { life, 3 },
            { score, 10 },
            { backgroundObject, 2 },
            { foundParticle, 2 }
        };
    }
}