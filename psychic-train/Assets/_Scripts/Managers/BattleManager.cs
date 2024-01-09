using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost, NoBattle }

public class BattleManager : MonoBehaviour
{
    private GameManager _gameManager = GameManager._instance;
    
    public BattleState battleState;
    
    //Enemies that get loaded from GameManager
    public UnitStats[] enemyToLoad;

    public GameObject playerModel;
    public GameObject enemyModel;

    private Vector3 playerBattleStation = new Vector3(-3, 1, 0);
    private Vector3 enemyBattleStation = new Vector3(3, 1, 0);

    [SerializeField] private GameObject enemyHealthHUD;
    [SerializeField] private GameObject enemyNameHud;
    [SerializeField] private GameObject enemyLevelHUD;
    
    
    
    
    public int playerhealth, playerDMG, enemyHealth, enemyDMG;
    
    public BattleSceneLoaderConfig sceneToLoadBack;

    public Dialogue combatDialogue;
    private void Awake()
    {
       enemyToLoad[0]= _gameManager.enemyToLoad[0];
    }

    private void Start()
    {
        SetHud();
        battleState = BattleState.Start;
        StartCoroutine(SetupBattle());
    }
    

    IEnumerator SetupBattle()
    {
        
        playerModel = GameManager._instance.playerUnits[0].unitModel;
        enemyModel = enemyToLoad[0].unitModel;

        playerModel.transform.position = playerBattleStation;
        enemyModel.transform.position = enemyBattleStation;
        
        Instantiate(playerModel);
        Instantiate(enemyModel);

        playerhealth = GameManager._instance.playerUnits[0].currentHP;
        playerDMG = GameManager._instance.playerUnits[0].damage;

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
        
        if (battleState != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerAttack());
        
    }

    IEnumerator PlayerAttack()
    {
        //Damage the enemy
        
        enemyHealth-= playerDMG;
        enemyHealthHUD.GetComponent<Slider>().value = enemyHealth;
        
        combatDialogue.dialogueBox = "You did " + playerDMG + " Damage.";
        
        yield return new WaitForSeconds(2f);
        
        //check if the enemy is dead
        if (enemyToLoad[0].currentHP <= 0)
        {
            //end battle
            battleState = BattleState.Won;
            EndBattle();
        }
        else
        {
            //Enemy Turn
            battleState = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
            

        }
        
    }

    private IEnumerator EnemyTurn()
    {
        combatDialogue.dialogueBox = enemyToLoad[0].unitName + " Turn to attack!";

        yield return new WaitForSeconds(2f);

        playerhealth -= enemyDMG;
        
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

    public void SetHud()
    {
       
         //= enemyToLoad[0].unitName;
        
        enemyNameHud.GetComponent<TextMeshProUGUI>().text =enemyToLoad[0].unitName;
        enemyLevelHUD.GetComponent<TextMeshProUGUI>().text = "Lvl " + enemyToLoad[0].unitLevel;
        enemyHealthHUD.GetComponent<Slider>().maxValue = enemyToLoad[0].maxHP;
        enemyHealthHUD.GetComponent<Slider>().value = enemyToLoad[0].currentHP;
        
        
    }
    public bool TakeDamage(int dmg)
    {
        enemyToLoad[0].currentHP -= dmg;

        if (enemyToLoad[0].currentHP <= 0)
            return true;
        else
            return false;
    }
    
}

   


