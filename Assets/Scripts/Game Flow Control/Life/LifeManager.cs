using Cysharp.Threading.Tasks;
using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;
using Utilities.Enums;
using Utilities.Signals;

public class LifeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform lifeParent;

    private Stack<Life> lifes = new();

    public int NumberOfLives => lifes.Count;

    private void StartGame() => CreateLifes(3); 

    private async void CreateLifes(int numberOfLifes)
    {
        if(numberOfLifes < 0)
        {
            Debug.LogError("LifeManager: CreateLifes, number of lives is below zero!");
            return;
        }

        for(int i = 0;i < numberOfLifes;i++)
        {
            Life newLife = FactoryManager.instance.GetLife();
            newLife.transform.SetParent(lifeParent);
            lifes.Push(newLife);

            float timer = 0f;
            while(timer < Constants.LifeTimeBetweenCreation)
            {
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
        }
    }

    private void DecreaseLife()
    {
        if (NumberOfLives == 0)
            return;

        lifes.Pop().KillInsideImageAnimation();

        if(NumberOfLives == 0)
            Signals.OnLifeEnded?.Invoke();
    }


    private void OnEnable()
    {
        Signals.OnFailClick += DecreaseLife;
        Signals.OnGameStart += StartGame;
    }
    private void OnDisable()
    {
        Signals.OnFailClick -= DecreaseLife;
        Signals.OnGameStart -= StartGame;
    }
}
