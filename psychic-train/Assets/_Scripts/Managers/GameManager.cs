using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
