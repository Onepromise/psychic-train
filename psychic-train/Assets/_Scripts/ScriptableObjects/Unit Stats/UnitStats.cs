using UnityEditor.Animations;
using UnityEngine;


[CreateAssetMenu(fileName = "Unit stats")]
public class UnitStats : ScriptableObject
{
    public string unitName;
    public GameObject unitModel;

    public int unitLevel;
    public int damage;
    public int defence;
    public int mDamage;
    public int mDefence;
    public int speed;

    public int maxHP;
    public int currentHP;

    public Sprite unitImage;

    public string sceneLocation;
    public string battleScene;

    public AnimatorController animatorController;

}