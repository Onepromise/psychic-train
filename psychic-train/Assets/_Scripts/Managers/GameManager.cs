using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    private static GameObject _instance;
    
    public static GameManager GetInstance()
    {
        return _gameManager;
    }

    public GameState gameState;

    private void Awake()
    {
        _gameManager = this;
        
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.OverWorld:
                break;
            case GameState.Combat:
                
                break;
            case GameState.Menus:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    
}

public enum GameState
{
    OverWorld,
    Combat,
    Menus
}
