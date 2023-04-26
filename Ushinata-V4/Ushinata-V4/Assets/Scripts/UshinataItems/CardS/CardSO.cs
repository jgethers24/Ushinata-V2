using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CardSO : ScriptableObject
{
    public string cardName;
    public string itemDescription;
    public int power, manaCost;
    [SerializeField]
    private Sprite itemSprite;

    public void PreviewCard()
    {
        GameObject.Find("CardStatManager").GetComponent<CardStats>().
            PreviewCardStats(power, manaCost, cardName, itemDescription, itemSprite);
    }
    public void TurnOffPreviewStats()
    {
        GameObject.Find("CardStatManager").GetComponent<CardStats>().
            PreviewCardStats(power, manaCost, cardName, itemDescription, itemSprite);
    }

    /*public void EquipItem()
    {
        //Update Stats
        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerstats.strength += power;
        playerstats.magic += manaCost;

        playerstats.UpdateEquipmentStats();
    }

    public void UnEquipItem()
    {
        //Update Stats
        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerstats.strength -= power;
        playerstats.magic -= manaCost;

        playerstats.UpdateEquipmentStats();
    }*/
}