using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image character1Sprite;
    public TextMeshProUGUI character1Name;
    public TextMeshProUGUI character1Level;
    public TextMeshProUGUI character1hpText;
    public TextMeshProUGUI character1manaText;

    public Canvas mainMenu;


    private void Start()
    {
        UpdateMenu();
    }


    private void Update()
    {
        if (mainMenu.enabled)
        {
            UpdateMenu(); 
        }
    }

    private void UpdateMenu()
    {
        var playerUnit = GameManager._instance.playerUnits[0];
        
        character1Sprite.sprite = playerUnit.unitImage;
        character1Name.text = playerUnit.unitName;
        character1Level.text = "Level: "+ playerUnit.unitLevel;
        character1hpText.text = playerUnit.currentHP + " / " + playerUnit.maxHP;
        character1manaText.text = "0/0";
        
    }
    
}
