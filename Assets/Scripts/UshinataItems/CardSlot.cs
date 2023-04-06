using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
//functionally brackeys item script
public class CardSlot : MonoBehaviour, IPointerClickHandler
{
    //public ItemSO itemSO;
    //public EquipmentSO equipment;
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;



    //===ITEM SLOT===//


    [SerializeField]
    private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InvenManager invenManager;



    void Start()
    {
        itemImage.sprite = emptySprite;
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
    }


    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)//object ref
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
        if (thisItemSelected)
        {
            bool usable = invenManager.UseItem(itemName);
            if (usable)
            {
                Debug.Log("Using itemslot " + itemName + " " + this.quantity);
                this.quantity -= 1;
                if (this.quantity <= 0)
                {
                    EmptySlot();
                }
            }

            //invenManager.UseItem(itemName);

        }
        else
        {
            invenManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
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
