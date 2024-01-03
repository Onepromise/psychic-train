using System;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance;

    public BattleState battleState;
    
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    

    public void UpdateBattleState(BattleState newState)
    {
        battleState = newState;
        switch (newState)
        {
            case BattleState.Start:
                break;
            case BattleState.PlayerTurn:
                break;
            case BattleState.EnemyTurn:
                break;
            case BattleState.Won:
                break;
            case BattleState.Lost:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}
