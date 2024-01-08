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
    
    //Enemies that get loaded from SceneLoader
    public UnitStats[] enemyToLoad;

    public GameObject playerModel;
    public GameObject enemyModel;

    private Vector3 playerBattleStation = new Vector3(-3, 1, 0);
    private Vector3 enemyBattleStation = new Vector3(3, 1, 0);

    public int playerhealth, playerDMG, enemyHealth, enemyDMG;
    
    public BattleSceneLoaderConfig sceneToLoadBack;

    public Dialogue combatDialogue;
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
        battleState = BattleState.NoBattle;
    }

    private void Update()
    {
        if (battleState == BattleState.Start)
        {
            StartCoroutine(SetupBattle());
        }
    }
    

    IEnumerator SetupBattle()
    {
        playerModel = GameManager._instance.PlayerUnits[0].unitModel;
        enemyModel = enemyToLoad[0].unitModel;

        playerModel.transform.position = playerBattleStation;
        enemyModel.transform.position = enemyBattleStation;
        
        Instantiate(playerModel);
        Instantiate(enemyModel);

        playerhealth = GameManager._instance.PlayerUnits[0].currentHP;
        playerDMG = GameManager._instance.PlayerUnits[0].damage;

        enemyHealth = enemyToLoad[0].currentHP;
        enemyDMG = enemyToLoad[0].damage;
        

        combatDialogue.dialogueBox = "Battle has started!";
        
        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        battleState = BattleState.PlayerTurn;
        combatDialogue.dialogueBox ="You must make a move!";
    }

    public void OnAttackButton()
    {
        Debug.Log("You have pressed the attack!");
        
        // if (battleState != BattleState.PlayerTurn)
        //     return;
        // StartCoroutine(PlayerAttack());
        
    }

    IEnumerator PlayerAttack()
    {
        //Damage the enemy
        enemyHealth-= playerDMG;

        combatDialogue.dialogueBox = "You did " + playerDMG + " Damage.";
        
        yield return new WaitForSeconds(2f);
    }


    private void EndBattle()
    {
        if (battleState == BattleState.Won)
        {
            Debug.Log("You Won the battle");
        }
        else if (battleState == BattleState.Lost)
        {
            Debug.Log("You Lost the battle");
        }
    }

   
    
    
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
