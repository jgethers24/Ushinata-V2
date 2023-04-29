using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Narration", menuName = "Narration/Dialogue/Node/CloseShop")]
public class ShopCloseNode : DialogueNode
{
    [SerializeField]
    private DialogueNode m_NextNode;
    public DialogueNode NextNode => m_NextNode;
    [SerializeField]
    public GameObject InventoryMenu;

    public override bool CanBeFollowedByNode(DialogueNode node)
    {

        return m_NextNode == node;
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {
        InventoryMenu = GameObject.Find("InventoryCanvas");

        InventoryMenu.GetComponent<InvenManager>().CloseShop();
        visitor.Visit(this);

    }

}