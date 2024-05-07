using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utilities.Enums;
using Utilities.Signals;

public class GameManager : MonoBehaviour
{
    public static GameState gameState { get; private set; }

    private void Start()
    {
        SetGameState(GameState.Play);
        Signals.OnGameStart?.Invoke();
    }

    public void SetGameState(GameState newGameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                break;
            case GameState.Pause:
                break;
        }

        gameState = newGameState;

        switch (newGameState)
        {
            case GameState.Play:
                break;
            case GameState.Pause:
                break;
        }

        Signals.OnGameStateChanged?.Invoke(gameState);
    }

    private void WinGame()
    {
        SetGameState(GameState.Success);
        print("WON");
    }

    private void LoseGame()
    {
        SetGameState(GameState.Fail);
        print("LOST");
    }

    private void OnEnable()
    {
        Signals.OnLifeEnded += LoseGame;
        Signals.OnScoreFinished += WinGame;
    }
    private void OnDisable()
    {
        Signals.OnLifeEnded -= LoseGame;
        Signals.OnScoreFinished -= WinGame;
    }

}
