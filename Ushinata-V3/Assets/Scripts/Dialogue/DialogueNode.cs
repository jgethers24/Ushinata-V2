using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField]
    private NarrationLine m_DialogueLine;

    public NarrationLine DialogueLine => m_DialogueLine;

    public abstract bool CanBeFollowedByNode(DialogueNode node);
    public abstract void Accept(DialogueNodeVisitor visitor);
}
