using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.FilePathAttribute;
using Random = UnityEngine.Random;


public class AIDetector : MonoBehaviour
{
    [SerializeField] GameObject TP1;
    [SerializeField] GameObject TP2;
    [SerializeField] GameObject TP3;
    [SerializeField] GameObject TP4;
    [SerializeField] GameObject TP5;
    [SerializeField] GameObject TP6;
    [SerializeField] GameObject TP7;
    [SerializeField] GameObject TP8;
    [SerializeField] GameObject TP9;
    [SerializeField] GameObject TP10;
    [SerializeField] GameObject TP11;
    [SerializeField] GameObject TP12;

    Vector3 TP1Location;
    Vector3 TP2Location;
    Vector3 TP3Location;
    Vector3 TP4Location;
    Vector3 TP5Location;
    Vector3 TP6Location;
    Vector3 TP7Location;
    Vector3 TP8Location;
    Vector3 TP9Location;
    Vector3 TP10Location;
    Vector3 TP11Location;
    Vector3 TP12Location;

    public GameObject bullet;
    public Transform bulletPos;
    public int tpCounter;
    private float timer;
    private float randomLocation;

    void Start()
    {
        TP1Location = TP1.transform.position;
        TP2Location = TP2.transform.position;
        TP3Location = TP3.transform.position;
        TP4Location = TP4.transform.position;
        TP5Location = TP5.transform.position;
        TP6Location = TP6.transform.position;
        TP7Location = TP7.transform.position;
        TP8Location = TP8.transform.position;
        TP9Location = TP9.transform.position;
        TP10Location = TP10.transform.position;
        TP11Location = TP11.transform.position;
        TP12Location = TP12.transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            randomLocation = Random.Range(0, 12);
            if (randomLocation == 1) 
            {
                TeleportEnemy(TP1Location);
                timer = 0;
            }

            else if (randomLocation == 2)
            {
                TeleportEnemy(TP2Location);
                timer = 0;
            }

            else if (randomLocation == 3)
            {
                TeleportEnemy(TP3Location);
                timer = 0;
            }

            else if (randomLocation == 4)
            {
                TeleportEnemy(TP4Location);
                timer = 0;
            }

            else if (randomLocation == 5)
            {
                TeleportEnemy(TP5Location);
                timer = 0;
            }

            else if (randomLocation == 6)
            {
                TeleportEnemy(TP6Location);
                timer = 0;
            }

            else if (randomLocation == 7)
            {
                TeleportEnemy(TP7Location);
                timer = 0;
            }

            else if (randomLocation == 8)
            {
                TeleportEnemy(TP8Location);
                timer = 0;
            }

            else if (randomLocation == 9)
            {
                TeleportEnemy(TP9Location);
                timer = 0;
            }

            else if (randomLocation == 10)
            {
                TeleportEnemy(TP10Location);
                timer = 0;
            }

            else if (randomLocation == 11)
            {
                TeleportEnemy(TP11Location);
                timer = 0;
            }

            else if (randomLocation == 12)
            {
                TeleportEnemy(TP12Location);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    void TeleportEnemy(Vector3 tPLocation)
    {
        gameObject.transform.position = tPLocation;
    }
}
