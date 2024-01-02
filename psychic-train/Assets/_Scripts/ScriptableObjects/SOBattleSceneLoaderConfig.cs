using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "BattleSceneLoaderConfig")]
public class SOBattleSceneLoaderConfig : ScriptableObject
{
   public string sceneToLoad;
   public string sceneFrom;

}
