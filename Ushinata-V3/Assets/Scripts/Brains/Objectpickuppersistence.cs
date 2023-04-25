using UnityEngine;
using System.Collections;


public class Objectpickuppersistence : MonoBehaviour
{
   [SerializeField]public GameObject Pickup1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup1"))
        {
            //GameControl.control.Pickup1count += 1;
            GameControl.control.Pickup1state = 0;
        }
    }
    void Update()
    {
        if (GameControl.control.Pickup1state == 0)
        {
            Destroy(Pickup1);
        }
    }
}