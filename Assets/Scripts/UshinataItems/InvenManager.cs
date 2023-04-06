using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManager : MonoBehaviour
{
    public static InvenManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("mor than 1 instance of inventory found!!!!!!!");
            return;
        }
        instance = this;            
    }

    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    public GameObject CardMenu;

    //private bool menuActivated;
    public ItemSlot[] itemSlot;
    public EquipmentSlot[] equipmentSlot;
    public EquippedSlot[] equippedSlot;

    public CardSlot[] cardSlot;

    public ItemSO[] itemSOs;
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("mor than 1 instance of inventory found!!!!!!!");
            return;
        }
        instance = this;
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            Inventory();
        if (Input.GetButtonDown("EquipmentMenu"))
            Equipment();
        if (Input.GetButtonDown("CardMenu"))
            Card();
    }
    void Inventory()
    {
        if (InventoryMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            EquipmentMenu.SetActive(false);
        }
    }
    void Equipment()
    {
        if (EquipmentMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(true);
            CardMenu.SetActive(false);
        }
    }
    void Card()
    {
        if (CardMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(true);
        }
    }
    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if(itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }          
        }
        return false;
    }
    //object ref
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription,ItemType itemType, GameObject itemObject)
    {
        if (itemType == ItemType.Consumable || itemType== ItemType.none || itemType == ItemType.collectible || itemType== ItemType.Card)
        {
            if (itemType == ItemType.Card)
            {
                for (int i = 0; i < cardSlot.Length; i++)
                {
                    Debug.Log("  x2  ");
                    if (cardSlot[i].isFull == false && cardSlot[i].itemName == itemName || cardSlot[i].quantity == 0)
                    {
                        Debug.Log("  x3  ");
                        int leftOverItems = cardSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);//object ref
                        if (leftOverItems > 0)
                        {
                            Debug.Log("  x4  ");
                            
                            leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType, itemObject); //object ref                 
                        }
                        return leftOverItems;
                    }     
                }return quantity;
            }
            else 
            {
                for (int i = 0; i < itemSlot.Length; i++)
                {
                    Debug.Log("  x2  ");
                    if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
                    {
                        Debug.Log("  x3  ");
                        int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);//object ref
                        if (leftOverItems > 0)
                        {
                            Debug.Log("  x4  ");
                            leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType, itemObject);  //object ref              
                        }
                        return leftOverItems;
                    }       
                }          
            }return quantity;
        }
        else
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemName == itemName || equipmentSlot[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType, itemObject);//object ref
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType, itemObject);//object ref   
                    }
                    return leftOverItems;
                }
            }          
        }return quantity;
    }


        
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < cardSlot.Length; i++)
        {
            cardSlot[i].selectedShader.SetActive(false);
            cardSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].selectedShader.SetActive(false);
            equipmentSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equippedSlot.Length; i++)
        {
            equippedSlot[i].selectedShader.SetActive(false);
            equippedSlot[i].thisItemSelected = false;
        }
    }
}

public enum ItemType
{
    none, Weapon, Charm, CursedGear, Card, Consumable, collectible,
};