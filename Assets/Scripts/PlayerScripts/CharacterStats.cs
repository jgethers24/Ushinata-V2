using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;

    //BaseStats
    public int BasemaxHealth;
    public int BaseStrength;
    public int BaseMagic;
    public int BaseSpeed;

    //currentStats
    public int maxHealth;
    public int currentHealth;
    public TMP_Text hP;
    //public Stat armor;
    public int strength;
    public int magic;
    public int speed;
    private void Awake()
    {  
        currentHealth = BasemaxHealth;
        maxHealth = BasemaxHealth;
        strength = BaseStrength;
        magic = BaseMagic;
        speed = BaseSpeed;
        instance = this;
    }
    void Update()
    {
        //newMaxHealth = statModifier.ChangeHealth();
        
        
        //statChange =  statModifier.amountToChangeStat;
        hP.text = "HP: " + currentHealth + "/" + maxHealth;
        if (Input.GetKeyDown(KeyCode.T))
        {           
            TakeDamage(10);
            Debug.Log("oof");
        }
    }
    public void TakeDamage (int damage)
    {
        //damage -= armor.GetValue();
        //damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage.");
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //Die in some  way
        //This is meant to be overwritten
        Debug.Log("ded");
    }
    public int ChangeHealth(int amountToChangeStat)
    {
        
        Debug.Log("permanent health  "+  amountToChangeStat);
        instance.maxHealth += amountToChangeStat;
        Debug.Log("XXXXXXXXXXX");
        return instance.maxHealth;
    }
    public int RestoreHealth(int amountToChangeStat)
    {

        Debug.Log("heal pot  " + amountToChangeStat);
        currentHealth += amountToChangeStat;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("XXXXXXXXXXX");
        return currentHealth;
    }
    public int ChangeSpeed(int amountToChangeStat)
    {

        Debug.Log("Usin sdf sf sdf sds sdf sfds g  " + amountToChangeStat);
        instance.speed += amountToChangeStat;
        Debug.Log("XXXXXXXXXXX");
        return instance.speed;
    }
    /*public int ChangeHealth()
    {
        int newMaxHealth = maxHealth.GetValue();
        newMaxHealth += statChange;
        return newMaxHealth;
    }*/


    [SerializeField]
    public int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        return baseValue;
    }
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}