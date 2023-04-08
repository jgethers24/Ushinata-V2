using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
//functionally brackeys item script
public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public GameObject itemObject; //--------------------spawning object------------------------------//
    public Sprite emptySprite;
    public ItemType itemType;
    private GameObject inGameMainHandObject;//--------------------spawning object------------------------------//
   
    
    //===ITEM SLOT===//
    [SerializeField]
    private Image itemImage;

    //===equippedslots===//
    [SerializeField]
    private EquippedSlot weaponSlot, cursedGearSlot, charmSlot;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InvenManager invenManager;
    private EquipmentSOLibrary equipmentSOLibrary;

    void Start()
    {
        //object ref
        //itemImage.sprite = emptySprite;
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
        
        inGameMainHandObject = GameObject.Find("MainHand").GetComponent<GameObject>();//--------------------spawning object------------------------------//
    }


    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType, GameObject itemObject)//--------------------spawning object------------------------------//
    {
        //Check to see if the slot is already full
        if (isFull)
            return quantity;

        //Update ITEM TYPE
        this.itemType = itemType;

        //Update Name
        this.itemName = itemName;

        //Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //Update Description
        this.itemDescription = itemDescription;

        //Update Quantity
        this.quantity = 1;
        isFull = true;

        //update object
        //object ref


        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        if (isFull)
        {
            if (thisItemSelected)
            {
                EquipGear();

            }
            else
            {
                invenManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
                {
                    if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                        equipmentSOLibrary.equipmentSO[i].PreviewEquipment();
                }

            }
        }
        else
        {
            GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffPreviewStats();
            invenManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
        
    }
    private void EquipGear()
    {
        if (itemType == ItemType.Charm)
            charmSlot.EquipGear(itemSprite, itemName, itemDescription, itemObject);//object ref
        if (itemType == ItemType.Weapon)
        {
            weaponSlot.EquipGear(itemSprite, itemName, itemDescription, itemObject);//object ref
            inGameMainHandObject =  itemObject;  //--------------------spawning object------------------------------//
        }

        if (itemType == ItemType.CursedGear)
            cursedGearSlot.EquipGear(itemSprite, itemName, itemDescription, itemObject);//object ref

        EmptySlot();
    }
    private void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        isFull = false;
    }

    public void OnRightClick()
    {
        // for dropping items check out NightRun studio https://www.youtube.com/watch?v=lgmmDGqBX4k&list=PLSR2vNOypvs6eIxvTu-rYjw2Eyw57nZrU&index=10
        // i dont think i need that funtion rn
    }

}
