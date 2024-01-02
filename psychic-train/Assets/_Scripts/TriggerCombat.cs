using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCombat : MonoBehaviour
{
    public SOBattleSceneLoaderConfig sceneLoaderConfig;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            SceneToLoad();
        }
        
    }

    private void SceneToLoad()
    {
        SceneManager.LoadScene(sceneLoaderConfig.sceneToLoad);
    }
    
}
