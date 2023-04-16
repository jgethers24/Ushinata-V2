using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellSO spellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    public void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = spellToCast.spellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        if (spellToCast.lifetime <= 0f)
        {
            Destroy(this.gameObject);
        }
        //Destroy(this.gameObject, spellToCast.lifetime);
    }

    public void Update()
    {
        if(spellToCast.speed > 0)
            transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //apply spell effects to whatever we hit
        //apply hit particle effects
        //apply sound effects
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(spellToCast.damageAmount);
            //Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
