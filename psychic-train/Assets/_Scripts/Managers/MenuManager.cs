using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image character1Sprite;
    public TextMeshProUGUI character1Name;
    public Slider character1HealthBar;
    public Slider character1ManaBar;
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
        character1HealthBar.value = playerUnit.currentHP;
        character1HealthBar.maxValue = playerUnit.maxHP;
        character1Level.text = "Level: "+ playerUnit.unitLevel;
        character1hpText.text = playerUnit.currentHP + " / " + playerUnit.maxHP;
        character1manaText.text = "0/0";
        character1ManaBar.value = 0;
        character1ManaBar.maxValue = 0;
    }
    
}
