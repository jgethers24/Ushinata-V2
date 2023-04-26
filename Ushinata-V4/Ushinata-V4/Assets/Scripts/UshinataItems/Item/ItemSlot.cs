using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
//functionally brackeys item script
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    //object ref
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;

    [SerializeField]
    private int maxNumberOfItems;

    //===ITEM SLOT===//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InvenManager invenManager;

    //===ITEM DESCRIPTION SLOT===//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;


    void Start()
    {
        
        GameObject.DontDestroyOnLoad(this.gameObject);
        itemDescriptionImage.sprite = emptySprite;
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

        //update obj
        //object ref

        //Update Description
        this.itemDescription = itemDescription;

        //Update Quantity
        this.quantity += quantity;
        if(this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        
            //Return the Leftovers
            int extraItems= this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }
        //Update Quantity Text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
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
                quantityText.text = this.quantity.ToString();
                if (this.quantity <=0)
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
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {
        // for dropping items check out NightRun studio https://www.youtube.com/watch?v=lgmmDGqBX4k&list=PLSR2vNOypvs6eIxvTu-rYjw2Eyw57nZrU&index=10
        // i dont think i need that funtion rn
    }
    
}
