using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Narration", menuName = "Narration/Dialogue/Node/Basic")]
public class BasicDialogueNode : DialogueNode
{
    [SerializeField]
    private DialogueNode m_NextNode;
    public DialogueNode NextNode => m_NextNode;
  
    public override bool CanBeFollowedByNode(DialogueNode node)
    {
        
        return m_NextNode == node;
    }

    public override void Accept(DialogueNodeVisitor visitor)
    {

        visitor.Visit(this);

    }
    
}