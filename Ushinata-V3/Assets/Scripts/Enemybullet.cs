using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float life = 3;
    CharacterStats damageScript;

    void Start()
    {
        damageScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject,life);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
            damageScript.TakeDamage(10);
        }
        else if (col.gameObject.tag=="BlockObject")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.name.Contains("BackWall"))
        {
            Destroy(gameObject);
        }
    }
}
