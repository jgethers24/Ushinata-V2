using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position3TP : MonoBehaviour
{
    public bool l3 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            l3 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            l3 = false;
        }
    }
}
