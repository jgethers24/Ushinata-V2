using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSManager : MonoBehaviour
{
    public bool hasBeenMet;
    public bool hasSword;
    public bool hasStaff;
    public static BSManager instance;
    public Currency playercurrency;

    [SerializeField] private int swordValue = 10;
    [SerializeField] private int staffValue = 5;

    // Start is called before the first frame update
    void Awake()
    {
        hasBeenMet = false;
        hasStaff = true;
        hasSword = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     * [SerializeField] private bool hasEnoughMana;
     *  
     *  [SerializeField] private float currentMana;
     spellToCast = MochiBall;
            spellManaCost = MochiBallSO.manaCost;
            hasEnoughMana = currentMana - spellManaCost >= 0f;
     */
}
