using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;

    public string nextScene;
    
    public static SceneLoader GetInstance()
    {
        return _instance;
    }
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

    public void ToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NewGame()
    {
        ToScene("Village Scene");
        GameManager gameManager = GameManager._instance;
        gameManager.ChangeState(GameState.OverWorld);
    }

   
    
}

