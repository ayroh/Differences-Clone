using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Signals;

public class LevelManager : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private Levels allLevels;
    [SerializeField] private FactoryManager factoryManager;


    private void StartGame()
    {
        CreateLevel(allLevels.levels[0]);
    }

    private void CreateLevel(LevelData levelData)
    {
        SpriteObject background1 = null, background2 = null;
        factoryManager.FillSpriteObjectPair(background1, background2, levelData.background);

        for (int i = 0;i < levelData.differences.Count;++i)
        {
            DifferenceObject difference1 = null, difference2 = null;
            factoryManager.FillDifferenceObjectPair(difference1, difference2, levelData.differences[i]);
        }

        for (int i = 0;i < levelData.bothLevelSprites.Count;++i)
        {
            SpriteObject bothLevelSprite1 = null, bothLevelSprite2 = null;
            factoryManager.FillSpriteObjectPair(bothLevelSprite1, bothLevelSprite2, levelData.bothLevelSprites[i]);
        }
    }


    private void OnEnable() => Signals.OnGameStart += StartGame;
    private void OnDisable() => Signals.OnGameStart -= StartGame;
}
