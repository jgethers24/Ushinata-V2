using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatMovementPlayer : MonoBehaviour
{
    private GameObject cardSystem;
    //[SerializeField]
    public float speed = 0.8f;
    //[SerializeField]
    public float rayLength = 0.4f;
    public Transform Point;

    public bool moving;
    private void Start()
    {
        Point.parent = null;
    }
    private void Update()
    {
        
        if(transform.position==Point.position)
        {
            moving = false;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, Point.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Point.position) <= 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.A)&& !moving)
            {
                if (!Physics.Raycast(transform.position, Vector3.left,rayLength))
                {
                    Point.position += Vector3.left;
                    moving = true;
                }
                //Point.position += Vector3.left;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !moving)
            {
                if (!Physics.Raycast(transform.position, Vector3.right, rayLength))
                {
                    Point.position += Vector3.right;
                    moving = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W) && !moving)
            {
                if (!Physics.Raycast(transform.position, Vector3.forward, rayLength))
                {
                    Point.position += Vector3.forward;
                    moving = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) && !moving)
            {
                if (!Physics.Raycast(transform.position, Vector3.back, rayLength))
                {
                    Point.position += Vector3.back;
                    moving = true;
                }
            }
            /*
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    Point.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    //Point.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    //Point.position = transform.position + Vector3.forward;
                    Point.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
                }
            */
        }
    }
    void AttackPattern()
    {
        //cardSystem = this.GetComponent<PlayerCardSystem>();
        //cardSystem.cast;
    }
}


