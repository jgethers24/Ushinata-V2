using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardStats : MonoBehaviour
{
    //public int power, manaCost;

    //[SerializeField]
    //private TMP_Text powerText, manaCostText;

    [SerializeField]
    private TMP_Text powerPreText, manaCostPreText, cardNamePreText, cardDescriptionPreText;
    [SerializeField]
    private Image previewImage;
    [SerializeField]
    private TMP_Text combatPowerPreText, combatManaCostPreText, combatCardNamePreText, CombatcardDescriptionPreText;
    [SerializeField]
    private Image combatPreviewImage;

    [SerializeField]
    private GameObject selectedItemStats;
    [SerializeField]
    private GameObject selectedItemImage;
    [SerializeField]
    private GameObject cardDescriptionBox;


    private void Start()
    {
        //UpdateCardStats();
    }
    public void UpdateCardStats()
    {
        //powerText.text = power.ToString();
        //manaCostText.text = manaCost.ToString();
    }

    public void PreviewCardStats(int power, int manaCost,string cardName, string cardDescription, Sprite itemSprite)
    {
        powerPreText.text = power.ToString();
        manaCostPreText.text = manaCost.ToString();
        cardDescriptionPreText.text = cardDescription.ToString();
        cardNamePreText.text = cardName.ToString();
        previewImage.sprite = itemSprite;
        //selectedItemStats.SetActive(true);
        //selectedItemImage.SetActive(true);
        //cardDescriptionBox.SetActive(true);
    }
    public void TurnOffPreviewStats(int power, int manaCost, string cardName, string cardDescription, Sprite itemSprite)
    {
        powerPreText.text = "";
        manaCostPreText.text = "";
        cardDescriptionPreText.text = "";
        cardNamePreText.text = "";
        previewImage.sprite = null;
        //selectedItemStats.SetActive(false);
        //selectedItemImage.SetActive(false);
        //cardDescriptionBox.SetActive(false);
    }

}