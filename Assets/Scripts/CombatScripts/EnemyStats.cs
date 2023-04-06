using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;

    [SerializeField] private float maxHealth = 50f;
    private float currentHealth;

    public int strength;
    public int magic;
    public int speed;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("ded");
            Destroy(this.gameObject);
        }
    }
}