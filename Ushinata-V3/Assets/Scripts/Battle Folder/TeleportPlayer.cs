using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] GameObject TPMiddle;
    [SerializeField] GameObject TPRight;
    [SerializeField] GameObject TPLeft;

    Vector3 TPMidLocation;
    Vector3 TPRightLocation;
    Vector3 TPLeftLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        TPMidLocation = TPMiddle.transform.position;
        TPRightLocation = TPRight.transform.position;
        TPLeftLocation = TPLeft.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TeleportOurPlayer(TPMidLocation);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TeleportOurPlayer(TPRightLocation);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TeleportOurPlayer(TPLeftLocation);
        }
    }

    void TeleportOurPlayer(Vector3 tPLocation)
    {
        gameObject.transform.position = tPLocation;
        Debug.Log(tPLocation + "Works!");
    }
}
