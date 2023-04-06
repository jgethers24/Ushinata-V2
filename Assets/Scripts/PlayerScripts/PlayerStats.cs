using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int strength, magic, speed;

    [SerializeField]
    private TMP_Text strengthText, magicText, speedText;

    [SerializeField]
    private TMP_Text strengthPreText, magicPreText, speedPreText;
    [SerializeField]
    private Image previewImage;

    [SerializeField]
    private GameObject selectedItemStats;
    [SerializeField]
    private GameObject selectedItemImage;

    private void Start()
    {
        UpdateEquipmentStats();
    }
    public void UpdateEquipmentStats()
    {
        strengthText.text = strength.ToString();
        magicText.text = magic.ToString();
        speedText.text = speed.ToString();
    }

    public void PreviewEquipmentStats(int strength,int magic, int speed, Sprite itemSprite)
    {
        strengthPreText.text = strength.ToString();
        magicPreText.text = magic.ToString();
        speedPreText.text = speed.ToString();

        previewImage.sprite = itemSprite;
        selectedItemStats.SetActive(true);
        selectedItemImage.SetActive(true);
    }
    public void TurnOffPreviewStats()
    { 
        selectedItemStats.SetActive(false);
        selectedItemImage.SetActive(false);
    }

}
