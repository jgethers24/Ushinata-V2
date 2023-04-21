using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour//,Interactable
{
    /*
    [SerializeField] Dialog dialog;
    public bool inRange = false;
    [SerializeField] public GameObject dialogObj;
    public void Update()
    {
        
        bool interactInput = Input.GetButtonDown("Interact");
        if(inRange && interactInput)
        {
            if (dialogObj.activeSelf)
            {
                Debug.Log("acti");
                SimpleDialogManager.Instance.HandleUpdate();
                Debug.Log("active");
                return;
            }
            else
            {
                Debug.Log("updootin");
                SimpleDialogManager.Instance.ShowDialog(dialog);
                Debug.Log("button works");
            }   
            
        }
            

        //if (inRange )//&& interacting)
        // {
        //    Debug.Log("button works");
        //  SimpleDialogManager.Instance.ShowDialog(dialog);
        //}
    }
    private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
            //if(interacting)
                //SimpleDialogManager.Instance.ShowDialog(dialog);

        }
    }
    private void OnTriggerExit(Collider other)
    {
      if (other.gameObject.tag == "Player") ;
        inRange = false;
        SimpleDialogManager.Instance.HideDialog(dialog);
    }
    */
}
