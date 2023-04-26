using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position1TP : MonoBehaviour
{
    public bool l1 = false;

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
            l1 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            l1 = false;
        }
    }
}
