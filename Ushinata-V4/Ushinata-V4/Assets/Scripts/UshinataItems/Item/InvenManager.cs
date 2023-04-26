using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvenManager : MonoBehaviour
{
    public static InvenManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("mor than 1 instance of inventory found!!!!!!!");
            return;
        }
        instance = this;            
    }

    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    public GameObject CardMenu;
    public GameObject CombatCardMenu;
    public GameObject MainMenu;
    public GameObject customBar;
    public ItemSlot[] itemSlot;
    public EquipmentSlot[] equipmentSlot;
    public EquippedSlot[] equippedSlot;

    public CardQueue cardQueuee;
    public CardQueue[] cardQueue;
    public CardSlot[] cardSlot;
    public PlayerDeck[] playerDeck;
    public CombatPlayerDeck[] playerCombatDeck;
    public bool deckShowing = false;

    //public EquipmentSO[] equipmentSOs;---------------
    public ItemSO[] itemSOs;
    string sceneName;
    public float time;
    public float interpolationPeriod = 1.0f;
    void Start()
    {

    }
    void Update()
    {

            
        if (deckShowing == false)     
        {        
            if (cardQueue[0].slotInUse && !cardQueue[1].slotInUse || cardQueue[1].slotInUse && !cardQueue[2].slotInUse ||
                    cardQueue[2].slotInUse && !cardQueue[3].slotInUse || cardQueue[3].slotInUse && !cardQueue[4].slotInUse)
            {
                Debug.Log("crunching");
                cardQueuee.CrunchQueue();
            }  
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "StartingZone")
                Inventory();
        }
        
        if (Input.GetButtonDown("EquipmentMenu"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "StartingZone")
                Equipment();
        }
            
        if (Input.GetButtonDown("CardMenu"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "StartingZone")
                Card();
        }
        if (Input.GetButtonDown("CombatCardMenu"))
        {
            cardQueuee.CrunchQueue();
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            customBar = GameObject.Find("CustomBar");
            if (sceneName == "CombatScene2" && customBar.GetComponent<CustomBarScript>().fullBar)
                CombatCard();
        }

    }
    void Menu()
    {
        if (MainMenu.activeSelf)
        {
            MainMenu.SetActive(false);
        }
        else
        {
            MainMenu.SetActive(true);
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);

        }
    }
    void Inventory()
    {
        if (InventoryMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);
        }
    }
    void Equipment()
    {
        if (EquipmentMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(true);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);
        }
    }
    void Card()
    {
        if (CardMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(true);
            CombatCardMenu.SetActive(false);
        }
    }
    void CombatCard()
    {
        if (CombatCardMenu.activeSelf)
        {
            cardQueuee.CrunchQueue();
            deckShowing = true;
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(false);
            deckShowing = false;

            customBar.GetComponent<CustomBarScript>().Reset();
            customBar.GetComponent<CustomBarScript>().Unpause();
        }
        else
        {
            cardQueuee.CrunchQueue();
            deckShowing = false;
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
            CardMenu.SetActive(false);
            CombatCardMenu.SetActive(true);
            deckShowing = true;
            MainMenu.SetActive(false);

            customBar.GetComponent<CustomBarScript>().Pause();
        }
    }
    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if(itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }          
        }
        return false;
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription,ItemType itemType, GameObject itemObject)
    {
        if (itemType == ItemType.Consumable || itemType== ItemType.none || itemType == ItemType.collectible || itemType== ItemType.Card)
        {
            if (itemType == ItemType.Card)
            {
                for (int i = 0; i < cardSlot.Length; i++)
                {
                    if (cardSlot[i].isFull == false && cardSlot[i].itemName == itemName || cardSlot[i].quantity == 0)
                    {
                        int leftOverItems = cardSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);//object ref
                        if (leftOverItems > 0)
                        {
                            
                            leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType, itemObject); //object ref                 
                        }
                        return leftOverItems;
                    }     
                }return quantity;
            }
            else 
            {
                for (int i = 0; i < itemSlot.Length; i++)
                {
                    if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
                    {
                        int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);//object ref
                        if (leftOverItems > 0)
                        {
                            leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType, itemObject);  //object ref              
                        }
                        return leftOverItems;
                    }       
                }          
            }return quantity;
        }
        else
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemName == itemName || equipmentSlot[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType, itemObject);//object ref
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType, itemObject);//object ref   
                    }
                    return leftOverItems;
                }
            }          
        }return quantity;
    }
        
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < cardSlot.Length; i++)
        {
            cardSlot[i].selectedShader.SetActive(false);
            cardSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].selectedShader.SetActive(false);
            equipmentSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equippedSlot.Length; i++)
        {
            equippedSlot[i].selectedShader.SetActive(false);
            equippedSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < playerDeck.Length; i++)
        {
            playerDeck[i].selectedShader.SetActive(false);
            playerDeck[i].thisItemSelected = false;
        }
        for (int i = 0; i < playerCombatDeck.Length; i++)
        {
            playerCombatDeck[i].selectedShader.SetActive(false);
            playerCombatDeck[i].thisItemSelected = false;
        }
        for (int i = 0; i < cardQueue.Length; i++)
        {
            cardQueue[i].selectedShader.SetActive(false);
            cardQueue[i].thisItemSelected = false;
        }
    }

}

public enum ItemType
{
    none, Weapon, Charm, CursedGear, Card, Consumable, collectible,
};