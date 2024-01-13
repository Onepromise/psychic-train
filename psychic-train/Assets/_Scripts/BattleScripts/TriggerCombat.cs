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
            GameManager._instance.enemyToLoad[0] = enemyUnit;
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
