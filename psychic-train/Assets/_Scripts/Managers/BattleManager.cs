using System;
using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager _instance;
    public static BattleManager GetInstance()
    {
        return _instance;
    }
    
    public BattleState battleState;
    
    public UnitStats[] enemyToLoad;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        battleState = BattleState.Start;
        StartCoroutine(SetupBattle());
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown("space"))
    //     {
    //         //Change the BattleState to Won
    //         battleState = BattleState.Won;
    //
    //     }
    // }

    IEnumerator SetupBattle()
    {
        Debug.Log("Setup Battle has started!");
        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        battleState = BattleState.PlayerTurn;
        
        Debug.Log("You must make a move!");
        if (Input.GetKeyDown("space"))
        {
            //Change the BattleState to Won
            battleState = BattleState.Won;
            EndBattle();
        }
    }

    private void EndBattle()
    {
        if (battleState == BattleState.Won)
        {
            Debug.Log("You Won the battle");
        }else if (battleState == BattleState.Lost)
        {
            Debug.Log("You Lost the battle");
        }
    }

    // public void UpdateBattleState(BattleState newState)
    // {
    //     battleState = newState;
    //     switch (newState)
    //     {
    //         case BattleState.Start:
    //             Debug.Log("The Battle has started!");
    //             break;
    //         case BattleState.PlayerTurn:
    //             break;
    //         case BattleState.EnemyTurn:
    //             break;
    //         case BattleState.Won:
    //             Debug.Log("We have won the battle!");
    //             GameManager.GetInstance().gameState = GameState.OverWorld;
    //             SceneLoader.GetInstance().ToOverworld();
    //             break;
    //         case BattleState.Lost:
    //             break;
    //         case BattleState.NoBattle:
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    //     }
    // }
}

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost,
    NoBattle
}
