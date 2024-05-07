using Cysharp.Threading.Tasks;
using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;
using Utilities.Signals;

public class LifeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform lifeParent;

    private int maxLife = 3;

    private Stack<Life> lifes = new();

    public int NumberOfLives => lifes.Count;

    private void Start()
    {
        CreateLifes(3);
    }


    public async void CreateLifes(int numberOfLifes = 3)
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

        await UniTask.Delay(2000);
        DecreaseLife();
        await UniTask.Delay(2000);
        DecreaseLife();
        await UniTask.Delay(2000);
        DecreaseLife();
    }

    private void DecreaseLife()
    {
        if (NumberOfLives == 0)
            return;

        lifes.Pop().KillInsideImageAnimation();

        if(NumberOfLives == 0)
            Signals.OnLifeEnded?.Invoke();
    }


    private void OnEnable() => Signals.OnFailClick += DecreaseLife;
    private void OnDisable() => Signals.OnFailClick -= DecreaseLife;
}
