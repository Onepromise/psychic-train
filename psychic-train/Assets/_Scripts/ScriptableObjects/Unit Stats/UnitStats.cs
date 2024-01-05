using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Unit stats")]
public class UnitStats : ScriptableObject
{
    public string unitName;
    public GameObject unitModel;

    public int unitLevel;
    public int damage;

    public int maxHP;
    public int currentHP;

    public Image unitImage;

}

