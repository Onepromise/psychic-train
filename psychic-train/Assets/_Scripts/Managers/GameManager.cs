using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    private static GameObject _instance;

    //public UnitStats[] enemyToLoad;
    
    public static GameManager GetInstance()
    {
        return _gameManager;
    }
    
    public GameObject[] playerUnit;
    public GameObject[] enemyUnit;

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
                Debug.Log("Back in the world!");
                break;
            case GameState.Combat:
                Debug.Log("Ready to Fight");
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
