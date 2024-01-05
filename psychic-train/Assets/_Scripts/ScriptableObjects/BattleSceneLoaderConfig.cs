using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "BattleSceneLoaderConfig")]
public class BattleSceneLoaderConfig : ScriptableObject
{
   public string sceneToLoad;
   public string sceneFrom;

}
