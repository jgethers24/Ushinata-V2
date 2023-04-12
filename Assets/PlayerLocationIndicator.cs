using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationIndicator : MonoBehaviour
{
    public bool l1 = false;
    public bool l2 = false;
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
        if (other.gameObject.tag == "Location1")
        {
            l2 = false;
            l3 = false;
            l1 = true;
        }
        else if (other.gameObject.tag == "Location2")
        {
            l3 = false;
            l1 = false;
            l2 = true;
            
        }
        else if (other.gameObject.tag == "Location3")
        {
            l1 = false;
            l2 = false;
            l3 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Location1")
        {
            l1 = false;
        }
        else if (other.gameObject.tag == "Location2")
        {
            l2 = false;
        }
        else if (other.gameObject.tag == "Location3")
        {
            l3 = false;
        }
    }
}
