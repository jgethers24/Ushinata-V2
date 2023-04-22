using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Narration", menuName = "Narration/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private DialogueNode m_FirstNode;
    public DialogueNode FirstNode => m_FirstNode;
}
