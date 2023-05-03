using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class PlayerCardSystem : MonoBehaviour
{
    [SerializeField] private Spell Stab, HolyFire, MochiBall, NagiSpear, ThunderDrum, WindStrike;
    [SerializeField] private SpellSO StabSO, HolyFireSO, MochiBallSO, NagiSpearSO, ThunderDrumSO, WindStrikeSO;
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
    [SerializeField] private Transform blockPoint;
    CombatMovementPlayer combatMovement;
    private bool castingMagic = false;

    [SerializeField] private GameObject blockObject;
    private float sinceBlock = 0f;
    private float blockCD = 2.0f;
    private float blockDuration = 0.5f;
    private bool isblocking = false;
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
    private Animator _animator;
    public void Start()
    {
        _animator = GetComponent<Animator>();
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
        bool meleeAttack = Input.GetButtonDown("Fire1");
        bool blocking = Input.GetButtonDown("Block");
        bool isSpellCastHeldDown = Input.GetButtonDown("SpellCast");
        
        if (!castingMagic && meleeAttack && (Time.timeScale == 1))
        {
            Debug.Log("melee");
            spellToCast = Stab;
            spellManaCost = StabSO.manaCost;
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);
            Debug.Log("melee");
        }
        if (!castingMagic && blocking && !isblocking && (Time.timeScale == 1))
        {
            _animator.Play("Block");
            Debug.Log("block");
            //Instantiate(blockObject);
            Instantiate(blockObject, blockPoint.position, blockPoint.rotation);
            isblocking = true;
            sinceBlock = 0.0f;
            Debug.Log("block");
        }
        if (isblocking)
        {
            sinceBlock += Time.deltaTime;
            if (blockDuration <= sinceBlock)
            {
                Destroy(GameObject.FindGameObjectWithTag("BlockObject"));
                if (blockCD <= sinceBlock)
                {
                    sinceBlock = 0.0f;
                    isblocking = false;
                }
            }
        }
        if (q4Name == "Holy Fire")//queueSlot.name == "Fireball")
        {
            spellToCast = HolyFire;
            spellManaCost = HolyFireSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            //Debug.Log("casting fire");
        }
        else if (q4Name == "Mochi Ball")
        {
            spellToCast = MochiBall;
            spellManaCost = MochiBallSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            //Debug.Log("casting beam");
        }
        else if (q4Name == "Nagi Spear")
        {
            spellToCast = NagiSpear;
            spellManaCost = NagiSpearSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            //Debug.Log("casting slash");
        }
        else if (q4Name == "Thunder Drum")
        {
            spellToCast = ThunderDrum;
            spellManaCost = ThunderDrumSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            //Debug.Log("casting slash");
        }
        else if (q4Name == "Wind Strike")
        {
            spellToCast = WindStrike;
            spellManaCost = WindStrikeSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
            //Debug.Log("casting slash");
        }
        else
        {
            return;
        }

        //bool hasEnoughMana = currentMana - spellToCast.spellToCast.manaCost >= 0f;

        if (!castingMagic && isSpellCastHeldDown && hasEnoughMana && (Time.timeScale == 1))
        {
            _animator.Play("Attack");
            castingMagic = true;
            currentMana -= spellManaCost;
            currentCastTimer = 0;
            CastSpell();
            Debug.Log("casting a spell");
        }
        if (castingMagic)
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

    }
    void CastSpell()
    {
        queueSlot.DeleteCard(); //cardQueue.DeleteCard();
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        Debug.Log("instantiating spell");
        //uiCardImage.sprite = cardQueue[4].itemSprite;
        cardQueue.CrunchQueue();
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