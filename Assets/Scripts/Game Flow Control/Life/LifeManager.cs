using Cysharp.Threading.Tasks;
using Factory;
using Pool;
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

    private List<Life> lifes = new();

    private int currentLife = -1;
    private int maxLife = 3;
    public int NumberOfLives => lifes.Count;

    private void StartGame() => CreateLifes(maxLife - (currentLife + 1));

    public async UniTask ReviveLifes(int numberOfLifes)
    {
        if (numberOfLifes < 0)
        {
            Debug.LogError("LifeManager: ReviveLifes, number of lives is below zero!");
            return;
        }

        int count = Mathf.Min(numberOfLifes, lifes.Count - (currentLife + 1));
        for (int i = 0;i < count;i++)
        {
            currentLife++;
            lifes[currentLife].PlayAnimation(Constants.LifeReviveLifeAnimationName);

            float timer = 0f;
            while (timer < Constants.LifeTimeBetweenCreation)
            {
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
        }
    }

    private async void CreateLifes(int numberOfLifes)
    {
        if(numberOfLifes < 0)
        {
            Debug.LogError("LifeManager: CreateLifes, number of lives is below zero!");
            return;
        }
        int count = Mathf.Min(numberOfLifes, lifes.Count - (currentLife + 1));

        await ReviveLifes(count);

        count = numberOfLifes - count;
        for(int i = 0;i < count;i++)
        {
            Life newLife = FactoryManager.instance.GetLife();
            newLife.transform.SetParent(lifeParent);
            lifes.Add(newLife);

            float timer = 0f;
            while(timer < Constants.LifeTimeBetweenCreation)
            {
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
            currentLife++;
        }
    }

    private void DecreaseLife()
    {
        if (NumberOfLives == 0)
            return;

        lifes[currentLife].PlayAnimation(Constants.LifeKillLifeAnimationName);

        if(--currentLife == -1)
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
