using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Enums;
using Utilities.Signals;

public class GameManager : MonoBehaviour
{
    public static GameState gameState { get; private set; }

    private void Start()
    {
        SetGameState(GameState.Play);
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
}
