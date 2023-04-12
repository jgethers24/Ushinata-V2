using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour, IPointerClickHandler
{
    //SLOT APPEARANCE//
    [SerializeField]
    private Image slotImage;

    //object ref

    [SerializeField]
    private TMP_Text slotName;

    [SerializeField]
    private Image playerDisplayImage;

    //SLOT DATA//
    [SerializeField]
    private ItemType itemType = new ItemType();
    public int cardSlotNumber;
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;
    private GameObject itemObject;

    private InvenManager invenManager;
    private CardSOLibrary cardSOLibrary;

    public CombatPlayerDeck[] playerCombatDeck;
    //OTHER VARIABLES//
    public bool slotInUse;
    
    [SerializeField]
    public GameObject selectedShader;
    [SerializeField]
    public bool thisItemSelected;
    [SerializeField]
    private Sprite emptySprite;
    void Start()
    {
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
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
    void OnLeftClick()
    {
        if (thisItemSelected && slotInUse)
        {
            RemoveCardFromDeck();
            for (int i = 0; i < playerCombatDeck.Length ; i++)
            {
                if (playerCombatDeck[i].combatSlotNumber == cardSlotNumber)
                {
                    playerCombatDeck[i].DeleteCard();
                }

            }        
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
    void OnRightClick()
    {

    }
    void Update()
    {
        if (!slotInUse)
            slotImage.sprite = emptySprite;
    }

    public void AddCardToDeck(Sprite itemSprite, string itemName, string itemDescription)
    {
        //if something is already occupying equip slot
        if (slotInUse)
            RemoveCardFromDeck();
        //Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        //Update Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        
        slotInUse = true;

    }
    public void RemoveCardFromDeck()
    {
        invenManager.DeselectAllSlots();
        invenManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType, itemObject);

        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
    public void DeleteCard()
    {
        invenManager.DeselectAllSlots();
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
}