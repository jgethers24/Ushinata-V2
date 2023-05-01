using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSound : MonoBehaviour
{
    public AudioSource interactSound;

    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player")
        {    
            interactSound.Play();
        }
    }
}
