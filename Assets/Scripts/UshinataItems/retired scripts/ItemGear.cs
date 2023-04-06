using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemGear", menuName = "Item/Create New ItemGear")]
public class ItemGear : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
}
