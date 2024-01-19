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
        character1Sprite.sprite = GameManager._instance.playerUnits[0].unitImage;
        character1Name.text = GameManager._instance.playerUnits[0].unitName;
        character1HealthBar.value = GameManager._instance.playerUnits[0].currentHP;
        character1HealthBar.maxValue = GameManager._instance.playerUnits[0].maxHP;
        character1Level.text = "Level: "+GameManager._instance.playerUnits[0].unitLevel;
        character1hpText.text = GameManager._instance.playerUnits[0].currentHP + " / " +
                                GameManager._instance.playerUnits[0].maxHP;
        character1manaText.text = "0/0";
        character1ManaBar.value = 0;
        character1ManaBar.maxValue = 0;

    }
    
}
