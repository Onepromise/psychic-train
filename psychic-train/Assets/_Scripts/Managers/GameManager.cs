using System;
using UnityEngine;

public enum GameState { OverWorld, Combat, Menus, Loading, MainMenu }
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameState CurrentState { get; private set; }
    
    //Do I need this?
    BattleManager _battleManager = BattleManager.GetInstance();
    
    public UnitStats[] PlayerUnits;

    public Dialogue dialogue;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
    private void Start()
    {
        CurrentState = GameState.MainMenu;
        
    }
    
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log("GameState changed to: " + newState);

        
        switch (newState)
        {
            case GameState.OverWorld:
                
                break;
            case GameState.Combat:
                
                break;
            case GameState.Menus:
                //change input controlls
                break;
            case GameState.Loading:
                // Main scene for loading data
                break;
            case GameState.MainMenu:
                //Similar to LoadingScene, but better looking.
                break;
        }
    }


 

}


