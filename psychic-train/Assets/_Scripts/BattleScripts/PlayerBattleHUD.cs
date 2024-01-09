using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpSlider;
    GameManager _gameManager = GameManager._instance;
    
    

    private void Awake()
    {
        
    }

    private void Start()
    {
        SetHud();
    }


    
    
    
    
    public void SetHud()
    {
        nameText.text = _gameManager.playerUnits[0].unitName;
        levelText.text = "Lvl " + _gameManager.playerUnits[0].unitLevel;
        hpSlider.maxValue = _gameManager.playerUnits[0].maxHP;
        hpSlider.value = _gameManager.playerUnits[0].currentHP;
    }
    
    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
    
    
}
