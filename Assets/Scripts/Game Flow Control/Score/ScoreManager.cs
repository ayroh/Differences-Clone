using Cysharp.Threading.Tasks;
using Factory;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using Utilities.Constants;
using Utilities.Signals;

namespace ScoreManage
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform scoreParent;

        private List<Score> scores = new();

        private int maxScore = 10;
        private int currentScore = 0;

        private async void StartGame()
        {
            await CleanScores();
            CreateScores(maxScore - scores.Count);
        }

        public async UniTask CleanScores()
        {
            for (int i = currentScore - 1;i >= 0;i--)
            {
                currentScore--;
                scores[i].PlayAnimation(Constants.ScoreCleanAnimationName);

                float timer = 0f;
                while (timer < Constants.ScoreTimeBetweenCreation)
                {
                    timer += Time.deltaTime;
                    await UniTask.NextFrame();
                }
            }
        }

        private async void CreateScores(int numberOfScores)
        {
            if (scores.Count >= numberOfScores)
                return;

            if (numberOfScores < 0)
            {
                Debug.LogError("LifeManager: CreateScores, number of scores is below zero!");
                return;
            }

            for (int i = 0;i < numberOfScores;i++)
            {
                Score newScore = FactoryManager.instance.GetScore();
                newScore.transform.SetParent(scoreParent);
                scores.Add(newScore);

                float timer = 0f;
                while (timer < Constants.ScoreTimeBetweenCreation)
                {
                    timer += Time.deltaTime;
                    await UniTask.NextFrame();
                }
            }
        }

        public Vector2 GetCurrentScoreCanvasPosition()
        {
            if(currentScore == -1)
            {
                Debug.LogError("ScoreManager: GetCurrentScoreCanvasPosition, there is no current score to return!");
                return default;
            }
            return scores[currentScore - 1].transform.position;
        }

        private void IncreaseScore()
        {
            if (currentScore == 10)
                return;

            scores[currentScore++].PlayAnimation(Constants.ScoreFoundAnimationName);

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

}

