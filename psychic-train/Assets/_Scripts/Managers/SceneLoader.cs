using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        
        
    }
    
    
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Playground");
        }
    }
}

