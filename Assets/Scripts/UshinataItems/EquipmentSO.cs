using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EquipmentSO : ScriptableObject
{
    public string itemName;
    public int strength, magic, speed;
    [SerializeField]
    private Sprite itemSprite;

    public void PreviewEquipment()
    {
        GameObject.Find("StatManager").GetComponent<PlayerStats>().
            PreviewEquipmentStats(strength, magic, speed, itemSprite);
    }
    public void EquipItem()
    {
        //Update Stats
        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerstats.strength += strength;
        playerstats.magic += magic;
        playerstats.speed += speed;

        playerstats.UpdateEquipmentStats();
    }

    public void UnEquipItem()
    {
        //Update Stats
        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerstats.strength -= strength;
        playerstats.magic -= magic;
        playerstats.speed -= speed;

        playerstats.UpdateEquipmentStats();
    }
}