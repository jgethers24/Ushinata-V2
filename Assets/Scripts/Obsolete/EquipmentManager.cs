using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    /*
    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    EquipmentSO[] currentEquipment;

    InvenManager inventory;

    public delegate void OnEquipmentChanged(EquipmentSO newItem, EquipmentSO oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    void Start()
    {
        
        inventory = InvenManager.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new EquipmentSO[numSlots];
    }
    public void Equip(EquipmentSO newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        EquipmentSO oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            
        }

        currentEquipment[slotIndex] = newItem;
    }

    */

}
