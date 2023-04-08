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
        if(thisItemSelected && slotInUse)
        {

        }
        invenManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        //if (thisItemSelected && slotInUse)  // gonna have to make some sorta code to place thecombat deck slot into the combat queue
        //AddToCombatQueue();
        //else
        //{
        //    for (int i = 0; i < cardSOLibrary.cardSO.Length; i++)
        //    {
        //        if (cardSOLibrary.cardSO[i].cardName == this.itemName)
        //            cardSOLibrary.cardSO[i].PreviewCard;
        //    }
        //}
        
    }
    void OnRightClick()
    {

    }
    void Update()
    {
        //cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
    }
    public void AddCardToCombatDeck(Sprite itemSprite, string itemName, string itemDescription)
    {
        Debug.Log("addingcardto combat");
        //if something is already occupying equip slot
        if (slotInUse)
        {
            RemoveCardFromCombatDeck();
            Debug.Log("removed");
        }     
        //AddToCombatQueue();

        else
        {
            Debug.Log("in the else");
            /*for (int i = 0; i < cardSOLibrary.cardSO.Length; i++)
            {
                Debug.Log("in the for");
                if (cardSOLibrary.cardSO[i].cardName == this.itemName)
                    cardSOLibrary.cardSO[i].PreviewCard();
            }*/


            Debug.Log("past the for");
            //Update Image
            this.itemSprite = itemSprite;
            slotImage.sprite = this.itemSprite;
            slotName.enabled = false;

            //Update Data
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            slotInUse = true;
            Debug.Log("exiting else");
        }
    }
    public void AddToCombatQueue()
    {
        //gonna have to change this to make it work to place cards into the Queue not into the card inventory. WITHOUT removing it from the combat inventory
        invenManager.DeselectAllSlots();
        invenManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType, itemObject);
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;

        slotInUse = false;
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
        //gonna have to change this to make it work to place cards into the Queue not into the card inventory. WITHOUT removing it from the combat inventory
        //invenManager.DeselectAllSlots();
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }
}

