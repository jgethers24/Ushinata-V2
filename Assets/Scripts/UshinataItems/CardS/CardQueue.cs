using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardQueue : MonoBehaviour, IPointerClickHandler
{
    //SLOT APPEARANCE//
    [SerializeField]
    private Image cardImage;

    //object ref

    [SerializeField]
    private TMP_Text cardName;

    public Image cardDescriptionImage;
    public TMP_Text cardDescriptionNameText;
    public TMP_Text cardDescriptionText;

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

        //Debug.Log("this slot is number: " + slotNumba + "  -");
        //int thisSlot = playerCombatDeck.Length;
        if (thisItemSelected && slotInUse)
        {
            DeleteCard();
            //RemoveCardFromDeck();
            /*for (int i = 0; i < playerCombatDeck.Length; i++)
            {
                Debug.Log("  in the for loop  ");
                if (playerCombatDeck[i].combatSlotNumber == cardSlotNumber)
                {
                    Debug.Log("  about to delete  ");
                    playerCombatDeck[i].DeleteCard();
                }

            }*/
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

    }

    public void AddCardToQueue(Sprite itemSprite, string itemName, string itemDescription)
    {
        //if something is already occupying equip slot
        if (slotInUse)
            Debug.Log("  addingCard ToQueue ");
        //RemoveCardFromDeck();
        //Update Image
        this.itemSprite = itemSprite;
        cardImage.sprite = this.itemSprite;
        cardName.enabled = false;

        //Update Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        // for (int i = 0; i < cardSOLibrary.cardSO.Length; i++)
        // {
        //if (cardSOLibrary.cardSO[i].cardName == this.itemName)
        //cardSOLibrary.cardSO[i].EquipItem();
        //}
        slotInUse = true;

    }
    public void RemoveCardFromDeck()
    {
        Debug.Log("  - " + this.cardSlotNumber + " -  ");
        invenManager.DeselectAllSlots();
        invenManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType, itemObject);
        /*
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotInUse = false; */

        //invenManager.DeselectAllSlots();
        //Update SlotImage
        this.itemSprite = emptySprite;
        cardImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
    public void DeleteCard()
    {
        //gonna have to change this to make it work to place cards into the Queue not into the card inventory. WITHOUT removing it from the combat inventory
        invenManager.DeselectAllSlots();
        //Update SlotImage
        this.itemSprite = emptySprite;
        cardImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
}