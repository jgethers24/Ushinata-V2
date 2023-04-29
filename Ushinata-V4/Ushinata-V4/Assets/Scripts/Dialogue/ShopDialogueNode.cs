using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


[Serializable]
public class ShopChoice
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

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Node/shop")]
public class ShopDialogueNode : DialogueNode
{
    public static ShopDialogueNode shopDialogueNode;

    [SerializeField]
    public GameObject InventoryMenu;
    [SerializeField]
    private ShopChoice[] m_Choices;
    public ShopChoice[] Choices => m_Choices;

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
        InventoryMenu = GameObject.Find("InventoryCanvas");

        InventoryMenu.GetComponent<InvenManager>().Shop();
        visitor.Visit(this);
        Debug.Log("visited!");
    }
}
