using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{

    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

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
}
    public enum StatToChange
    {
        none,
        hp,
        health,
        speed
    };
