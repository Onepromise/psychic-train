using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   public UnitStats unit;
   
   public string unitName;
   public int unitLevel;

   public int damage;

   public int maxHP;
   public int currentHP;


   public void Start()
   {
      unitName = unit.unitName;
      unitLevel = unit.unitLevel;
      damage = unit.damage;
      maxHP = unit.maxHP;
      currentHP = unit.currentHP;
   }
}
