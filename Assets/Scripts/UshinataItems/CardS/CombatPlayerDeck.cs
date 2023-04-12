using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CombatPlayerDeck : MonoBehaviour, IPointerClickHandler
{
    //SLOT APPEARANCE//
    [SerializeField]
    private Image slotImage;

    //object ref

    [SerializeField]
    private TMP_Text slotName;

    //[SerializeField]
    //private Image playerDisplayImage;

    [SerializeField]
    private CardQueue queueSlot0, queueSlot1, queueSlot2, queueSlot3, queueSlot4;

    //SLOT DATA//
    [SerializeField]
    private ItemType itemType = new ItemType();
    public int combatSlotNumber;
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;
    private GameObject itemObject;

    private InvenManager invenManager;
    private CardSOLibrary cardSOLibrary;

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
        
        //slotImage.sprite = emptySprite;
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
        
    }
    public void Awake()
    {
        //this.itemSprite = emptySprite;
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
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
    void OnLeftClick()
    {
        if (slotInUse)
        {
            if (thisItemSelected)
            {

                AddToCombatQueue();
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
            invenManager.DeselectAllSlots();
            selectedShader.SetActive(false);
            thisItemSelected = false;
        }
    }
    void OnRightClick()
    {

    }
    void Update()
    { 
            if(!slotInUse)
            slotImage.sprite = emptySprite;
    }
    public void AddCardToCombatDeck(Sprite itemSprite, string itemName, string itemDescription)
    {
        if (slotInUse)
        {
            RemoveCardFromCombatDeck();
        }     
        //AddToCombatQueue();

        else
        {
            //Update Image
            this.itemSprite = itemSprite;
            slotImage.sprite = this.itemSprite;
            slotName.enabled = false;

            //Update Data
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            slotInUse = true;
        }
    }
    public void AddToCombatQueue()
    {
        if (!queueSlot0.slotInUse)
        {
            queueSlot0.AddCardToQueue(itemSprite, itemName, itemDescription);
        }
        else if (/*queueSlot0.slotInUse &&*/ !queueSlot1.slotInUse)
        {
            queueSlot1.AddCardToQueue(itemSprite, itemName, itemDescription);
        }
        else if (!queueSlot2.slotInUse)
        {
            queueSlot2.AddCardToQueue(itemSprite, itemName, itemDescription);
        }
        else if (!queueSlot3.slotInUse)
        {
            queueSlot3.AddCardToQueue(itemSprite, itemName, itemDescription);
        }
        else if (!queueSlot4.slotInUse)
        {
            queueSlot4.AddCardToQueue(itemSprite, itemName, itemDescription);
        }
    }
    public void RemoveCardFromCombatDeck()
    {
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
    public void DeleteCard()
    {
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
}

