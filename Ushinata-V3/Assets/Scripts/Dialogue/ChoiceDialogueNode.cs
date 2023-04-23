using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


[Serializable]
public class DialogueChoice
{
    [SerializeField]
    private string m_ChoicePreview;
    [SerializeField]
    private DialogueNode m_ChoiceNode;
    

    public string ChoicePreview => m_ChoicePreview;
    public DialogueNode ChoiceNode => m_ChoiceNode;
    //[SerializeField]
   // private Currency currency;
   
   // [SerializeField] public int itemCost;

}

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/Choice")]
public class ChoiceDialogueNode : DialogueNode
{
    public static ChoiceDialogueNode myChoiceDialogueNode;
    

    [SerializeField]
    private DialogueChoice[] m_Choices;
    public DialogueChoice[] Choices => m_Choices;

    //if (GameObject.Find("Player").GetComponent<Currency>().money>= 0)
    //public static int cost = GameObject.Find("Blacksmith").GetComponent<ChoiceDialogueNode>.


    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        //int cost = DialogueChoice.itemCost;
        return m_Choices.Any(x => x.ChoiceNode == node);
        //else
        //{
        //    Debug.Log("u broke");
        //    return false;
        //}
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
