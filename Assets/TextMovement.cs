using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMovement : MonoBehaviour
{
    private Animator anim;

    IEnumerator Start()
    {
        anim = GetComponent<Animator>();
        
        while(true)
        {
            yield return new WaitForSeconds(2);

            anim.SetInteger("MovementIndex", Random.Range(0, 4));
            anim.SetTrigger("NextMove");
        }
    }
}
