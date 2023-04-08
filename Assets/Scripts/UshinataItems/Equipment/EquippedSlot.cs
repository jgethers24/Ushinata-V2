using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
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
    private EquipmentSOLibrary equipmentSOLibrary;

    private void Start()
    {
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
    }


    //OTHER VARIABLES//
    public bool slotInUse;
    [SerializeField]
    public GameObject selectedShader;

    [SerializeField]
    public bool thisItemSelected;

    [SerializeField]
    private Sprite emptySprite;

    public void OnPointerClick(PointerEventData eventData)
    {
        //On Left Click
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        //On Right Click
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    void OnLeftClick()
    {
        if (thisItemSelected && slotInUse)
            UnEquipGear();
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
    void OnRightClick()
    {
        UnEquipGear();
    }


    //object ref
    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription, GameObject itemObject)
    {
        //if something is already occupying equip slot
        if (slotInUse)
            UnEquipGear();

        //Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        //Update Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        //object ref

        //Update Display
        playerDisplayImage.sprite = itemSprite;

        //Update Player Stats
        for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
        {
            if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                equipmentSOLibrary.equipmentSO[i].EquipItem();
        }

        slotInUse = true;
    }
    public void UnEquipGear()
    {
        invenManager.DeselectAllSlots();
        //object ref
        invenManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType, itemObject);
        //Update SlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotName.enabled = true;
        //object ref

        playerDisplayImage.sprite = emptySprite;

        //Update Player Stats
        for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
        {
            if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                equipmentSOLibrary.equipmentSO[i].UnEquipItem();
        }
        GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffPreviewStats();
        slotInUse = false;
    }

}
