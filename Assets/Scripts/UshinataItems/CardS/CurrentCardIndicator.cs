using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class CurrentCardIndicator : MonoBehaviour
{
    [SerializeField]
    private Image uiCardImage;
    private Sprite uiImage;
    [SerializeField]
    private Image queueSlot;
    [SerializeField]
    private CardQueue queueCard;

    // Update is called once per frame
    void Update()
    {
        uiCardImage.sprite = queueCard.imageForUI;
        //uiCardImage = queueSlot;
    }
}
