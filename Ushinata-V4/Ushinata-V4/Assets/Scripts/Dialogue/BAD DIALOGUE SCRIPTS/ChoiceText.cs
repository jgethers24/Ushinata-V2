using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceText : MonoBehaviour
{
    TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    public TMP_Text Textfield => text;
}
