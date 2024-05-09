using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Signals;

public class LevelManager : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private Levels allLevels;


    private void StartGame()
    {
        CreateLevel(allLevels.levels[1]);
    }

    private void CreateLevel(LevelData levelData)
    {
        FactoryManager.instance.CreateBackgrounds(levelData.background);

        for (int i = 0;i < levelData.differences.Count;++i)
        {
            FactoryManager.instance.CreateDifferenceObjectPair(levelData.differences[i]);
        }

        for (int i = 0;i < levelData.bothLevelSprites.Count;++i)
        {
            FactoryManager.instance.CreateSpriteObjectPair(levelData.bothLevelSprites[i]);
        }
    }


    private void OnEnable() => Signals.OnGameStart += StartGame;
    private void OnDisable() => Signals.OnGameStart -= StartGame;
}
