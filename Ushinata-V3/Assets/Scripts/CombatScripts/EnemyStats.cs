using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;

    public float maxHealth;
    public float currentHealth;

    public int strength;
    public int magic;
    public int speed;
    //public bool isAlive = true;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        currentHealth = maxHealth;
        //isAlive = true;
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }*/

    // Update is called once per frame
    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            //isAlive = false;
            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
