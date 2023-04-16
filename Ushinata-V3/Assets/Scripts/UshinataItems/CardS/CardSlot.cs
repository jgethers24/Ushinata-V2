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
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;

    public Image cardDescriptionImage;
    public TMP_Text cardDescriptionNameText;
    public TMP_Text cardDescriptionText;

    //===ITEM SLOT===//
    //public CardSlot[] deckSlot;  ///========================================================

    [SerializeField]
    private Image itemImage;

    //===Deck Slots===//
    [SerializeField]
    private PlayerDeck deckSlot0, deckSlot1, deckSlot2, deckSlot3, deckSlot4, deckSlot5, deckSlot6
    , deckSlot7, deckSlot8, deckSlot9, deckSlot10, deckSlot11, deckSlot12, deckSlot13, deckSlot14;

    [SerializeField]
    private CombatPlayerDeck CdeckSlot0, CdeckSlot1, CdeckSlot2, CdeckSlot3, CdeckSlot4, CdeckSlot5, CdeckSlot6
    , CdeckSlot7, CdeckSlot8, CdeckSlot9, CdeckSlot10, CdeckSlot11, CdeckSlot12, CdeckSlot13, CdeckSlot14;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InvenManager invenManager;
    private CardSOLibrary cardSOLibrary;


    void Start()
    {
        
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
    }
    void Update()
    {
        if (!isFull)
            itemImage.sprite = emptySprite;
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
        if (isFull)
        {
            if (thisItemSelected)
            {
                
                AddCardToDeck();
                selectedShader.SetActive(false);
                thisItemSelected = false;
            }
            else
            {

                invenManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                for (int i = 0; i < cardSOLibrary.cardSO.Length; i++)
                {
                    if (cardSOLibrary.cardSO[i].cardName == this.itemName)
                        cardSOLibrary.cardSO[i].PreviewCard();
                }
            }
        }
        else
        {
            //selectedShader.SetActive(false);
            //thisItemSelected = false;

            invenManager.DeselectAllSlots();
            //this.thisItemSelected = false;
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }
    private void AddCardToDeck()
    {
        //if( deckSlot0.slotInUse)
        if (!deckSlot0.slotInUse)
        {
            deckSlot0.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot0.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }

        else if (deckSlot0.slotInUse && !deckSlot1.slotInUse)
        {
            deckSlot1.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot1.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot2.slotInUse)
        {
            deckSlot2.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot2.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot3.slotInUse)
        {
            deckSlot3.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot3.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot4.slotInUse)
        {
            deckSlot4.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot4.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot5.slotInUse)
        {
            deckSlot5.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot5.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot6.slotInUse)
        {
            deckSlot6.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot6.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot7.slotInUse)
        {
            deckSlot7.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot7.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot8.slotInUse)
        {
            deckSlot8.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot8.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot9.slotInUse)
        {
            deckSlot9.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot9.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot10.slotInUse)
        {
            deckSlot10.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot10.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot11.slotInUse)
        {
            deckSlot11.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot11.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot12.slotInUse)
        {
            deckSlot12.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot12.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot13.slotInUse)
        {
            deckSlot13.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot13.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        else if (itemType == ItemType.Card && !deckSlot14.slotInUse)
        {
            deckSlot14.AddCardToDeck(itemSprite, itemName, itemDescription);
            CdeckSlot14.AddCardToCombatDeck(itemSprite, itemName, itemDescription);
        }
        EmptySlot();
    }
    private void EmptySlot()
    {
        for (int i = 0; i < cardSOLibrary.cardSO.Length; i++)
        {
            if (cardSOLibrary.cardSO[i].cardName == this.itemName)
                cardSOLibrary.cardSO[i].TurnOffPreviewStats();
        }
        isFull = false;
        itemImage.sprite = emptySprite;

        //cardDescriptionNameText.text = "";
        //cardDescriptionText.text = "";
        //cardDescriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {
        // for dropping items check out NightRun studio https://www.youtube.com/watch?v=lgmmDGqBX4k&list=PLSR2vNOypvs6eIxvTu-rYjw2Eyw57nZrU&index=10
        // i dont think i need that funtion rn
    }
}