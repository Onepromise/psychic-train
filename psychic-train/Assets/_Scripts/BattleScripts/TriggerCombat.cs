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
            GameManager gameManager = GameManager._instance;
            gameManager.ChangeState(GameState.Combat);
            
            BattleManager.GetInstance().enemyToLoad[0] = enemyUnit;
            
            
            
            //loads the new combat scene
            SceneToLoad();
        }
        
        
    }
    private void SceneToLoad()
    {
        SceneManager.LoadScene(sceneLoaderConfig.sceneToLoad);
    }

    private void SceneToLoadBack()
    {
        SceneManager.LoadScene(sceneLoaderConfig.sceneFrom);
    }
    
}
