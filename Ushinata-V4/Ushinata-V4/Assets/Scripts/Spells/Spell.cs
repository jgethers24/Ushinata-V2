using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellSO spellToCast;
    private float spellLifeSpan;
    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    public void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = spellToCast.spellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        spellLifeSpan = spellToCast.lifetime;
        //Destroy(this.gameObject, spellToCast.lifetime);
    }

    public void Update()
    {
        spellLifeSpan -= Time.deltaTime;
        if (spellLifeSpan <= 0f)
        {
            Destroy(this.gameObject);
            spellLifeSpan = spellToCast.lifetime;
        }
        if (spellToCast.speed > 0)
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
