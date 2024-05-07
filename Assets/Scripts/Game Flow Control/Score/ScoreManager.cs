using Cysharp.Threading.Tasks;
using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;
using Utilities.Signals;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform scoreParent;

    private List<Score> scores = new();

    private int currentScore = 0;

    private void StartGame() => CreateScores(10);

    private async void CreateScores(int numberOfScores)
    {
        if (numberOfScores < 0)
        {
            Debug.LogError("LifeManager: CreateLifes, number of lives is below zero!");
            return;
        }

        for (int i = 0;i < numberOfScores;i++)
        {
            Score newScore = FactoryManager.instance.GetScore();
            newScore.transform.SetParent(scoreParent);
            scores.Add(newScore);

            float timer = 0f;
            while (timer < Constants.LifeTimeBetweenCreation)
            {
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
        }
    }

    private void IncreaseScore()
    {
        if (currentScore == 10)
            return;

        scores[currentScore++].FoundAnimation();

        if (currentScore == 10)
            Signals.OnScoreFinished?.Invoke();
    }


    private void OnEnable()
    {
        Signals.OnFound += IncreaseScore;
        Signals.OnGameStart += StartGame;
    }
    private void OnDisable()
    {
        Signals.OnFound -= IncreaseScore;
        Signals.OnGameStart -= StartGame;
    }
}
