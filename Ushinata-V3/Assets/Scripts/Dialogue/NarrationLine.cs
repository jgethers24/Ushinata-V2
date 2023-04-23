using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Narration", menuName = "Narration/Line")]
public class NarrationLine : ScriptableObject
{
    [SerializeField] private NarrationCharacter m_Speaker;
    [SerializeField] private string m_Text;
    public BSManager bSManager;
    public NarrationCharacter Speaker => m_Speaker;
    public string Text => m_Text;

    public void Update()
    {
        Debug.Log("Starting Ja Nega?");
    }
    public void Awake()
    {
        bSManager = GameObject.Find("BSManager").GetComponent<BSManager>();
    }
    
}
