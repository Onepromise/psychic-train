using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats stats;
    
    // public string unitName ;
    // public int unitLevel;
    // public int damage;
    // public int maxHP;
    // public int currentHP;
    private Animator _animator;

    private void Awake()
    {
        
        _animator = GetComponent<Animator>();
        // unitName = stats.unitName;
        // damage = stats.damage;
        // unitLevel = stats.unitLevel;
        // maxHP = stats.maxHP;
        // currentHP = stats.currentHP;
    }

    public bool TakeDamage(int dmg)
    {
        stats.currentHP = stats.currentHP - dmg;
        

        if (stats.currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        stats.currentHP += amount;
        if (stats.currentHP > stats.maxHP)
        {
            stats.currentHP = stats.maxHP;
        }
    }

    public void BackToScene()
    {
        SceneLoader sceneLoader = SceneLoader.GetInstance();
        sceneLoader.ToScene(stats.sceneLocation);
    }
    

}