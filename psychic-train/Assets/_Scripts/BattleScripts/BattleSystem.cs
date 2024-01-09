using System.Collections;
using TMPro;
using UnityEngine;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    //public Transform playerBattleStation;
    //public Transform enemyBattleStation;

    private Unit playerUnit;
    private Unit enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(BattleState.START);
    }
    
    public void ChangeState(BattleState newState)
    {
        state = newState;
        Debug.Log("GameState changed to: " + newState);

        
        switch (newState)
        {
            case BattleState.START:
                StartCoroutine(SetupBattle());
                break;
            case BattleState.PLAYERTURN:
                PlayerTurn();
                break;
            case BattleState.ENEMYTURN:
                StartCoroutine(EnemyTurn());
                break;
            case BattleState.WON:
                EndBattle();
                break;
            case BattleState.LOST:
                EndBattle();
                break;
        }
    }

    IEnumerator SetupBattle()
    {
        
        Debug.Log("Setup time");
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.stats.unitName + " has appeared!";
        
        
        playerHUD.SetHUD(playerUnit.stats);
        enemyHUD.SetHUD(enemyUnit.stats);

        yield return new WaitForSeconds(2f);

        ChangeState(BattleState.PLAYERTURN);

    }

    private void PlayerTurn()
    {
        Debug.Log("Player Turn");
        dialogueText.text = "Choose an action";
    }

    public void OnAttackButton()
    {
        Debug.Log("attack selected");
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAttack());
        }
        
    }
    
    public void OnHealButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        
        playerHUD.SetHP(playerUnit.stats.currentHP);
        dialogueText.text = "You feel renewed strength";

        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerAttack()
    {
        
        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.stats.damage);
        
        enemyHUD.SetHP(enemyUnit.stats.currentHP);
       
        dialogueText.text = "The attack is successful!";
        
        
        yield return new WaitForSeconds(2f);
        
        //check if the enemy is dead
        if (isDead)
        {
            //end battle
            ChangeState(BattleState.WON);
            
        }
        else
        {
            //Enemy Turn
            ChangeState(BattleState.ENEMYTURN);
            
        }
        //check state based on what happened

    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.stats.unitName + "attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.stats.damage);
        
        playerHUD.SetHP(playerUnit.stats.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            ChangeState(BattleState.LOST);
            
        }
        else
        {
            ChangeState(BattleState.PLAYERTURN);
           
        }
    }

    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }
}
