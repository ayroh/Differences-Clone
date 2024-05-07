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

    private int currentLife = 0;
    private int maxLife = 3;

    private Stack<Life> lifes = new();

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
            float timer = 0f;
            Life newLife = FactoryManager.instance.GetLife();
            newLife.transform.SetParent(lifeParent);
            lifes.Push(newLife);
            while(timer < Constants.LifeTimeBetweenCreation)
            {
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
        }

        currentLife = numberOfLifes - 1;
    }

    private void DecreaseLife()
    {
        if (currentLife == 0)
            return;

        if(--currentLife == 0)
            Signals.OnLifeEnded?.Invoke();
    }


    private void OnEnable() => Signals.OnFailClick += DecreaseLife;
    private void OnDisable() => Signals.OnFailClick -= DecreaseLife;
}
