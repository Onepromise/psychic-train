using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // private static UIManager _instance;
    // public static UIManager GetInstance()
    // {
    //     return _instance;
    // }
    //
    // private void Awake()
    // {
    //     if (_instance != null && _instance != this)
    //     {
    //         Destroy(this);
    //     }
    //     else
    //     {
    //         _instance = this;
    //     }
    // }
    //
    // public GameObject[] allCanvases;
    // private GameObject[] instantiatedCanvases;
    //
    // void Start()
    // {
    //     instantiatedCanvases = new GameObject[allCanvases.Length]; // Create array to store instances
    //     UpdateUI();
    // }
    //
    // private void UpdateUI()
    // {
    //     for (int i = 0; i < allCanvases.Length; i++)
    //     {
    //         instantiatedCanvases[i] = Instantiate(allCanvases[i]);
    //         instantiatedCanvases[i].SetActive(false); // Initially deactivate all
    //     }
    // }
    //
    // private void Update()
    // {
    //     // Handle UI switching based on game state here
    //     // Example:
    //     if (GameManager.GetInstance().gameState == GameState.MainMenu)
    //     {
    //         MainMenuHUD();
    //     }
    //     else if (GameManager.GetInstance().gameState == GameState.OverWorld)
    //     {
    //         WorldHUD();
    //     }
    //     else if (GameManager.GetInstance().gameState == GameState.Combat)
    //     {
    //         CombatHUD();
    //     }
    // }
    //
    // // Functions to enable specific canvases based on game state
    // private void MainMenuHUD()
    // {
    //     // Deactivate all canvases first
    //     foreach (GameObject canvas in instantiatedCanvases)
    //     {
    //         canvas.SetActive(false);
    //     }
    //     // Then activate the desired one
    //     instantiatedCanvases[0].SetActive(true);
    // }
    //
    // private void WorldHUD()
    // {
    //     // Deactivate all canvases first
    //     foreach (GameObject canvas in instantiatedCanvases)
    //     {
    //         canvas.SetActive(false);
    //     }
    //     // Then activate the desired one
    //    // instantiatedCanvases[0].SetActive(true);
    // }
    //
    // private void CombatHUD()
    // {
    //     // ... (Similar logic for CombatHUD)
    // }
}