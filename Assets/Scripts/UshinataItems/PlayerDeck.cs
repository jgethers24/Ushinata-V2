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

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;
    private GameObject itemObject;

    private InvenManager invenManager;
    //private EquipmentSOLibrary cardSOLibrary;

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
            RemoveCardFromDeck();
        else
        {
            invenManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            //for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
            //{
            //    if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
            //        equipmentSOLibrary.equipmentSO[i].PreviewEquipment();
            //}
        }
    }
    void OnRightClick()
    {

    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCardToDeck(Sprite itemSprite, string itemName, string itemDescription)
    {
        //if something is already occupying equip slot
        if (slotInUse)
            return;
        else
        {
            //Update Image
            this.itemSprite = itemSprite;
            slotImage.sprite = this.itemSprite;
            slotName.enabled = false;

            //Update Data
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            //object ref
            //Update Display
            //playerDisplayImage.sprite = itemSprite;
            //Update Player Stats
            //for (int i = 0; i < cardSOLibrary.equipmentSO.Length; i++)
            //{
            //if (cardSOLibrary.equipmentSO[i].itemName == this.itemName)
            //cardSOLibrary.equipmentSO[i].EquipItem();
            //}
            slotInUse = true;
        }        
    }
    public void RemoveCardFromDeck()
    {
        invenManager.DeselectAllSlots();
        invenManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType, itemObject);
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        //slotName.enabled = true;

        //playerDisplayImage.sprite = emptySprite;

        //Update Player Stats
        //for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
        //{
        //    if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
        //        equipmentSOLibrary.equipmentSO[i].UnEquipItem();
        //}
        //GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffPreviewStats();
        slotInUse = false;
    }
}
