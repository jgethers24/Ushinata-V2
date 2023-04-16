using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{

    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;
    
    
    //Wild Changes
    public int strength, magic, speed, health;
    [SerializeField]
    private Sprite itemSprite;
    //----------------------------
    public bool UseItem()
    {
        if (statToChange == StatToChange.hp)
        {
            CharacterStats characterStats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
            if (characterStats.currentHealth >= characterStats.maxHealth)
            {
                return false;
            }
            else
            {
                characterStats.RestoreHealth(amountToChangeStat);
                return true;
            }

        }
        else if (statToChange == StatToChange.health)
        {
            CharacterStats characterStats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
            if (characterStats.currentHealth == characterStats.maxHealth)
            {
                return false;
            }
            characterStats.ChangeHealth(amountToChangeStat);
        }
        return false;
    }

    //Wild Changes
    public void PreviewEquipment()
    {
        /*GameObject.Find("StatManager").GetComponent<PlayerStats>().
            PreviewEquipmentStats(strength, magic, speed, health, itemSprite);*/
        GameObject.Find("Player").GetComponent<CharacterStats>().
            PreviewEquipmentStats(strength, magic, speed, health, itemSprite);
    }
    public void EquipItem()
    {
        //Update Stats
        CharacterStats characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        characterStats.strength += strength;
        characterStats.magic += magic;
        characterStats.speed += speed;
        characterStats.maxHealth += health;

        characterStats.UpdateEquipmentStats();
    }

    public void UnEquipItem()
    {
        //Update Stats
        CharacterStats characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        characterStats.strength -= strength;
        characterStats.magic -= magic;
        characterStats.speed -= speed;
        characterStats.maxHealth -= health;

        characterStats.UpdateEquipmentStats();
    }
}
    public enum StatToChange
    {
        none,
        hp,
        health,
        speed
    };
