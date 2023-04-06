using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public TMP_Text healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthPoints.text = "HP: " + health + "/" + maxHealth;
    }
}
