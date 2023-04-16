using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public Transform attackPoint;

    public int strengthDamage;
    public int magicDamage;
    public Vector3 attackOffset;
    public float attackRange =1f;
    public LayerMask enemyLayers;

    void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayers);
        foreach(Collider player in hitPlayer)
        {
            Debug.Log("player got hit");
        }
    }    
}
/*
   if (other.gameObject.CompareTag("Enemy"))
{
    EnemyStats enemyStats = other.GetComponent<EnemyStats>();
    enemyStats.TakeDamage(spellToCast.damageAmount);
    //Destroy(this.gameObject);
}

Destroy(this.gameObject);
        }
        if (Collider other
        if (colInfo != null)
{
    colInfo.GetComponent<CharacterStats>().TakeDamage(strengthDamage);
    EnemyStats enemyStats = other.GetComponent<EnemyStats>();
    enemyStats.TakeDamage(spellToCast.damageAmount);
    //Destroy(this.gameObject);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(spellToCast.damageAmount);
            //Destroy(this.gameObject);
        }
    }
    */


