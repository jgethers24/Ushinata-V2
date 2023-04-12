using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    private Vector3 direction;
    public float force;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * force;
        direction = Vector3.back;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            Destroy(gameObject);
        }
    }
}
