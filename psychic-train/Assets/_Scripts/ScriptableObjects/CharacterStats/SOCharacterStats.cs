using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character stats")]
public class SOCharacterStats : ScriptableObject
{
    public string unitName;
    public GameObject unitModel;

    public int unitLevel;
    public int damage;

    public int maxHP;
    public int currentHP;

    public Image unitImage;

}


