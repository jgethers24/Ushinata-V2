using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerCardSystem : MonoBehaviour
{
    [SerializeField] private Spell Stab, Fireball, SwordSlash,LazerBeam;
    [SerializeField] private SpellSO StabSO, FireballSO, SwordSlashSO, LazerBeamSO;
    private Spell spellToCast;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    public TMP_Text mp;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeBetweenCasts = 2f;
    private float currentCastTimer;
    [SerializeField] private bool hasEnoughMana;
    private int spellManaCost;
    [SerializeField] private Transform castPoint;
    
    private bool castingMagic = false;

    public CardQueue cardQueue;
    [SerializeField]
    private CardQueue queueSlot;

    // Card Data
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
    private Sprite emptySprite;
    public bool slotInUse;

    private string q4Name;

    public void Start()
    {
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
    }
    private void Awake()
    {
        currentMana = maxMana;
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
        cardSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<CardSOLibrary>();
    }

    private void Update()
    {
        mp.text = "MP: " + Mathf.FloorToInt(currentMana) + "/" + maxMana;
        

        q4Name = queueSlot.GetComponent<CardQueue>().itemName;

        if (q4Name == "Fireball")//queueSlot.name == "Fireball")
        {
            spellToCast = Fireball;
            spellManaCost = FireballSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            Debug.Log("casting fire");
        }
        else if (q4Name == "LazerBeam")
        {
            spellToCast = LazerBeam;
            spellManaCost = LazerBeamSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            Debug.Log("casting beam");
        }
        else if (q4Name == "SwordSlash")
        {
            spellToCast = SwordSlash;
            spellManaCost = SwordSlashSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            Debug.Log("casting slash");
        }
        else
        {
            spellToCast = Stab;
            spellManaCost = StabSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            Debug.Log("casting stab");
        }
        bool testButton = Input.GetKeyDown(KeyCode.V);
        bool isSpellCastHeldDown = Input.GetButtonDown("SpellCast");
        //bool hasEnoughMana = currentMana - spellToCast.spellToCast.manaCost >= 0f;

        if(!castingMagic && isSpellCastHeldDown && hasEnoughMana)
        {
            
            castingMagic = true;
            currentMana -= spellManaCost; 

             currentCastTimer = 0;
            CastSpell();
            Debug.Log("casting a spell");
        }
        if(castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            if (currentCastTimer > timeBetweenCasts)
                castingMagic = false;
        }
        if (currentMana < maxMana && !castingMagic && !isSpellCastHeldDown)
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            if (currentMana > maxMana)
                currentMana = maxMana;
        }
        if (testButton)
        {
            Debug.Log("V button working");
        }
      
    }
    void CastSpell()
    {
        queueSlot.DeleteCard(); //cardQueue.DeleteCard();
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        Debug.Log("instantiating spell");
    }
    public void DeleteCard()
    {
       
        invenManager.DeselectAllSlots();
        //Update SlotImage
        this.itemSprite = emptySprite;
        cardImage.sprite = this.emptySprite;
        this.itemName = "";
        this.itemDescription = "";

        slotInUse = false;
    }



}
