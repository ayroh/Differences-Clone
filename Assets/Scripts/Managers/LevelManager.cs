using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private Levels allLevels;
    [SerializeField] private FactoryManager factoryManager;


    void Start()
    {
        CreateLevel(allLevels.levels[0]);
    }

    private void CreateLevel(LevelData levelData)
    {


        for(int i = 0;i < levelData.differences.Count;++i)
        {
            DifferenceObject difference1 = null, difference2 = null;
            factoryManager.FillDifferenceObjectPair(ref difference1, ref difference2, levelData.differences[i]);

            
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
