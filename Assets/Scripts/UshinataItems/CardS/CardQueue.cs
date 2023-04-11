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
    public string itemName;  //====================
    private string itemDescription;
    private GameObject itemObject;

    private InvenManager invenManager;
    private CardSOLibrary cardSOLibrary;

    public CombatPlayerDeck[] playerCombatDeck;
    //OTHER VARIABLES//
    public bool slotInUse;

    public CardQueue[] cardQueue;

    [SerializeField]
    public GameObject selectedShader;
    [SerializeField]
    public bool thisItemSelected;
    [SerializeField]
    private Sprite emptySprite;

    public GameObject CombatCardMenu;
    //private float time;
    //public float interpolationPeriod = 1.0f;
    void Start()
    {
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
    }
    private void Awake()
    {
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
    }
    void Update()
    {
        /*time += Time.deltaTime;
        if(cardQueue[1].slotInUse)
            Debug.Log("inUse");

        if (time >= interpolationPeriod)
        {

            time = 0.0f;
            if (invenManager.deckShowing==false)
            {
                Debug.Log("combat card menu button pressed");
                if (cardQueue[0].slotInUse && !cardQueue[1].slotInUse || cardQueue[1].slotInUse && !cardQueue[2].slotInUse ||
                    cardQueue[2].slotInUse && !cardQueue[3].slotInUse || cardQueue[3].slotInUse && !cardQueue[4].slotInUse)
                    CrunchQueue();

                //CrunchQueue();
            }
        }*/
            
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
        if (thisItemSelected && slotInUse)
        {
            DeleteCard();
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
        //Debug.Log("onRightClick");
        CrunchQueue();
        //Debug.Log("afterRightClick");
    }


    public void AddCardToQueue(Sprite itemSprite, string itemName, string itemDescription)
    {
        this.itemSprite = itemSprite;
        cardImage.sprite = this.itemSprite;
        cardName.enabled = false;

        //Update Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        slotInUse = true;

    }

    public void CrunchQueue()
    {
        Debug.Log("in crunch queue");
        for (int i = 0; i < 5; i++)
        {
            //Debug.Log("in i queue");
            //Debug.Log("in crunch queue first for");
            for (int j = 4; j > 0; j--)
            {
                //Debug.Log("j = "+ j);
                //Debug.Log("second for");
                if (!cardQueue[j].slotInUse && cardQueue[j - 1].slotInUse)
                {
                    //Debug.Log("top of if");
                    //move card from [i-1] to [i]
                    cardQueue[j].itemSprite = cardQueue[j - 1].itemSprite;
                    cardQueue[j].cardImage.sprite = cardQueue[j - 1].cardImage.sprite;
                    cardQueue[j].itemName = cardQueue[j - 1].itemName;
                    cardQueue[j].itemDescription = cardQueue[j - 1].itemDescription;
                    cardQueue[j].slotInUse = true;
                    cardQueue[j - 1].itemSprite = emptySprite;
                    cardQueue[j - 1].cardImage.sprite = emptySprite;
                    cardQueue[j - 1].itemName = "";
                    cardQueue[j - 1].itemDescription = "";
                    cardQueue[j - 1].slotInUse = false;
                    //Debug.Log("bottom of if");
                }
            }
        }
        
    }

    public void RemoveCardFromDeck()
    {
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