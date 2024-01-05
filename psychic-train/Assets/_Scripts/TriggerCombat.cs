using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCombat : MonoBehaviour
{
    public BattleSceneLoaderConfig sceneLoaderConfig;
    public UnitStats enemyUnit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            //loads the new combat scene
            SceneToLoad();
            GameManager.GetInstance().gameState = GameState.Combat;

            BattleManager.GetInstance().enemyToLoad[0] = enemyUnit;
        }
        
        
    }

    private void SceneToLoad()
    {
        SceneManager.LoadScene(sceneLoaderConfig.sceneToLoad);
    }
    
}
