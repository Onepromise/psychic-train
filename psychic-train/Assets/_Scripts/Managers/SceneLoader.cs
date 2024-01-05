using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;
    
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

    private void Update()
    {
        ToOverworld();
    }


    public void ToOverworld()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Playground"); 
        }
        
    }
}

