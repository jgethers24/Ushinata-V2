using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.FilePathAttribute;
using Random = UnityEngine.Random;


public class DummyKaiAI : MonoBehaviour
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
    //=========================================
    [SerializeField] GameObject PL1;
    [SerializeField] GameObject PL2;
    [SerializeField] GameObject PL3;
    [SerializeField] GameObject PL4;
    [SerializeField] GameObject PL5;
    [SerializeField] GameObject PL6;
    //====================================================

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

    public GameObject bulletPrefab;
    public Transform bulletPos;
    public float bulletSpeed = 10;

    private float timer;
    private float randomLocation;
    private float attackDelay;
    public float tpCounter;
    /*
    public position1TP L1;
    public position2TP L2;
    public position3TP L3;
    public position1TP L4;
    public position2TP L5;
    public position3TP L6;
    */
    void Start()
    {
        /*
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
        */
    }

    void Update()
    {
        if(GetComponent<EnemyStats>().currentHealth > 0f)
        {

            //====================================================
            if (TP1 == null)
            {
                TP1 = GameObject.Find("TP_1");
                TP2 = GameObject.Find("TP_2");
                TP3 = GameObject.Find("TP_3");
                TP4 = GameObject.Find("TP_4");
                TP5 = GameObject.Find("TP_5");
                TP6 = GameObject.Find("TP_6");
                TP7 = GameObject.Find("TP_7");
                TP8 = GameObject.Find("TP_8");
                TP9 = GameObject.Find("TP_9");
                TP10 = GameObject.Find("TP_10");
                TP11 = GameObject.Find("TP_11");
                TP12 = GameObject.Find("TP_12");
                PL1 = GameObject.Find("pLocation1");
                PL2 = GameObject.Find("pLocation2");
                PL3 = GameObject.Find("pLocation3");
                PL4 = GameObject.Find("pLocation4");
                PL5 = GameObject.Find("pLocation5");
                PL6 = GameObject.Find("pLocation6");


                //L1 = position1TP.Find("pLocation1");
                //pLocation1 would be L1
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
                Debug.Log("NULL NULL NULL");
            }

            //===================================================

            if (GetComponent<EnemyStats>().currentHealth > 50f)
            {
                timer += Time.deltaTime;

                //==========================================================================================================
                if (timer > 1.4)
                {
                    if (PL1.GetComponent<position1TP>().l1 == true || PL4.GetComponent<position1TP>().l1 == true) // for each of the if statements the only thing different is i changed the if from 
                    {                                                                                             //if (L1.l1 == true || L4.l1 == true) to what they currently are
                        randomLocation = Random.Range(0, 2);
                        if (randomLocation == 1)
                        {
                            TeleportEnemy(TP1Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            TeleportEnemy(TP2Location);
                            timer = 0;
                            shoot();
                        }
                    }
                    else if (PL2.GetComponent<position2TP>().l2 == true || PL5.GetComponent<position2TP>().l2 == true)
                    {
                        randomLocation = Random.Range(0, 2);
                        if (randomLocation == 1)
                        {
                            TeleportEnemy(TP5Location);
                            timer = 0;
                            shoot();
                        }
                        else
                        {
                            TeleportEnemy(TP6Location);
                            timer = 0;
                            shoot();
                        }
                    }
                    else if (PL3.GetComponent<position3TP>().l3 == true || PL6.GetComponent<position3TP>().l3 == true)
                    {
                        randomLocation = Random.Range(0, 2);
                        if (randomLocation == 1)
                        {
                            TeleportEnemy(TP9Location);
                            timer = 0;
                            shoot();
                        }
                        else
                        {
                            TeleportEnemy(TP10Location);
                            timer = 0;
                            shoot();
                        }
                    }
                    //==========================================================================================================

                    /*
                    if (L1.l1 == true || L4.l1 == true)
                    {
                        randomLocation = Random.Range(0, 2);
                        if (randomLocation == 1)
                        {
                            TeleportEnemy(TP1Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            TeleportEnemy(TP2Location);
                            timer = 0;
                            shoot();
                        }
                    }
                    else if (L2.l2 == true || L5.l2 == true)
                    {
                        randomLocation = Random.Range(0, 2);
                        if (randomLocation == 1)
                        {
                            TeleportEnemy(TP5Location);
                            timer = 0;
                            shoot();
                        }
                        else
                        {
                            TeleportEnemy(TP6Location);
                            timer = 0;
                            shoot();
                        }
                    }
                    else if (L3.l3 == true || L6.l3 == true)
                    {
                        randomLocation = Random.Range(0, 2);
                        if (randomLocation == 1)
                        {
                            TeleportEnemy(TP9Location);
                            timer = 0;
                            shoot();
                        }
                        else
                        {
                            TeleportEnemy(TP10Location);
                            timer = 0;
                            shoot();
                        }
                    }
                    */
                }
            }

            if (GetComponent<EnemyStats>().currentHealth <= 50f)
            {
                bulletSpeed = 8;
                timer += Time.deltaTime;
                if (timer > .8)
                {
                    randomLocation = Random.Range(0, 6);
                    if (randomLocation == 1)
                    {
                        if (tpCounter != randomLocation)
                        {
                            tpCounter = randomLocation;
                            TeleportEnemy(TP1Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            randomLocation = Random.Range(0, 6);
                        }
                    }

                    else if (randomLocation == 2)
                    {
                        if (tpCounter != randomLocation)
                        {
                            tpCounter = randomLocation;
                            TeleportEnemy(TP2Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            randomLocation = Random.Range(0, 6);
                        }
                    }
                    else if (randomLocation == 3)
                    {

                        if (tpCounter != randomLocation)
                        {
                            tpCounter = randomLocation;
                            TeleportEnemy(TP5Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            randomLocation = Random.Range(0, 6);
                        }
                    }
                    else if (randomLocation == 4)
                    {
                        if (tpCounter != randomLocation)
                        {
                            tpCounter = randomLocation;
                            TeleportEnemy(TP6Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            randomLocation = Random.Range(0, 6);
                        }
                    }
                    else if (randomLocation == 5)
                    {
                        if (tpCounter != randomLocation)
                        {
                            tpCounter = randomLocation;
                            TeleportEnemy(TP9Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            randomLocation = Random.Range(0, 6);
                        }
                    }
                    else if (randomLocation == 6)
                    {
                        if (tpCounter != randomLocation)
                        {
                            tpCounter = randomLocation;
                            TeleportEnemy(TP10Location);
                            shoot();
                            timer = 0;
                        }
                        else
                        {
                            randomLocation = Random.Range(0, 6);
                        }
                    }
                }
            }
        }
    }

    void shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletPos.forward * bulletSpeed;
    }

    void TeleportEnemy(Vector3 tPLocation)
    {
        gameObject.transform.position = tPLocation;
    }
}
