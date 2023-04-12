using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float life = 3;

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
        if (col.gameObject.name.Contains("Player"))
        {
            Destroy(gameObject);
        }
    }
}
