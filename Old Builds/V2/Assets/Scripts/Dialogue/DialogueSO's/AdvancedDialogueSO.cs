using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AdvancedDialogueSO : ScriptableObject
{
    // Start is called before the first frame update
    public DialogueActors[] actors;
    [Tooltip("Only needed if Random is selected as the actor name")]
    [Header("Random Actor Info")]
    public string randomActorName;
    public Sprite randomActorPortrait;

    [Header("Dialogue")]
    [TextArea]
    public string[] dialogue;

    [Tooltip("The words that will appear on the option buttons")]
    public string[] optionText;

    public AdvancedDialogueSO option0;
    public AdvancedDialogueSO option1;
    public AdvancedDialogueSO option2;
    public AdvancedDialogueSO option3;
}
