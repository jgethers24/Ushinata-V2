using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;

    //BaseStats
    public int BasemaxHealth;
    public int BaseStrength;
    public int BaseMagic;
    public int BaseSpeed;

    //currentStats
    public int maxHealth;
    public int currentHealth;
    public TMP_Text hP;
    //public Stat armor;
    public int strength;
    public int magic;
    public int speed;

    public static bool isGameOver;

    //some beeg changes beloe
    [SerializeField]
    private TMP_Text strengthText, magicText, speedText, healthText;

    [SerializeField]
    private TMP_Text strengthPreText, magicPreText, speedPreText, healthPreText;
    [SerializeField]
    private Image previewImage;


    private void Start()
    {
        UpdateEquipmentStats();
    }
    public void UpdateEquipmentStats()
    {
        strengthText.text = strength.ToString();
        magicText.text = magic.ToString();
        speedText.text = speed.ToString();
        healthText.text = maxHealth.ToString();
    }

    public void PreviewEquipmentStats(int strength, int magic, int speed, int health, Sprite itemSprite)
    {
        strengthPreText.text = strength.ToString();
        magicPreText.text = magic.ToString();
        speedPreText.text = speed.ToString();
        healthPreText.text = health.ToString();

        previewImage.sprite = itemSprite;
    }
    private void Awake()
    {  
        currentHealth = BasemaxHealth;
        maxHealth = BasemaxHealth;
        strength = BaseStrength;
        magic = BaseMagic;
        speed = BaseSpeed;
        instance = this;
    }
    void Update()
    {
        //newMaxHealth = statModifier.ChangeHealth();

        //hP.text = "HP: " + currentHealth + "/" + maxHealth;
        //statChange =  statModifier.amountToChangeStat;
        hP.text = "HP: " + Mathf.FloorToInt(currentHealth) + "/" + maxHealth;
        if (Input.GetKeyDown(KeyCode.T))
        {           
            TakeDamage(10);
        }      
    }
    public void TakeDamage (int damage)
    {
        //damage -= armor.GetValue();
        //damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameOver();
        }
    }
    public void gameOver()
    {
        SceneManager.LoadScene(3);
    }
    public int ChangeHealth(int amountToChangeStat)
    {
        
        Debug.Log("permanent health  "+  amountToChangeStat);
        instance.maxHealth += amountToChangeStat;
        Debug.Log("XXXXXXXXXXX");
        return instance.maxHealth;
    }
    public int RestoreHealth(int amountToChangeStat)
    {

        Debug.Log("heal pot  " + amountToChangeStat);
        currentHealth += amountToChangeStat;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("XXXXXXXXXXX");
        return currentHealth;
    }
    public int ChangeSpeed(int amountToChangeStat)
    {

        Debug.Log("Usin sdf sf sdf sds sdf sfds g  " + amountToChangeStat);
        instance.speed += amountToChangeStat;
        Debug.Log("XXXXXXXXXXX");
        return instance.speed;
    }
    /*public int ChangeHealth()
    {
        int newMaxHealth = maxHealth.GetValue();
        newMaxHealth += statChange;
        return newMaxHealth;
    }*/


    [SerializeField]
    public int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        return baseValue;
    }
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
