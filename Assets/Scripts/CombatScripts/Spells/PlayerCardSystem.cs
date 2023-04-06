using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeBetweenCasts = 2f;
    private float currentCastTimer;

    [SerializeField] private Transform castPoint;

    private bool castingMagic = false;
    private void Awake()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        bool isSpellCastHeldDown = Input.GetButtonDown("SpellCast");
        bool hasEnoughMana = currentMana-spellToCast.spellToCast.manaCost >= 0f;

        if(!castingMagic && isSpellCastHeldDown && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= spellToCast.spellToCast.manaCost;
            
            currentCastTimer = 0;
            CastSpell();
            Debug.Log("casting a spell");
        }
        if(castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            if (currentCastTimer > timeBetweenCasts)
                castingMagic = false;
        }
        if (currentMana < maxMana && !castingMagic && !isSpellCastHeldDown)
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            if (currentMana > maxMana)
                currentMana = maxMana;
        }
            
      
    }
    void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        Debug.Log("instantiating spell");
    }
    
}
