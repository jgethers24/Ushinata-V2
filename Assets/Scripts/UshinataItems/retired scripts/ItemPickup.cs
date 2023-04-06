using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemGear Item;
    public GameObject player;
    public GameObject thisItem;
    public float Dist;
    private float minDist = 2.0f;
    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
    /*private void OnMouseDown()
    {
        if()
        Pickup();
    }*/
    void Update()
    {
        Dist = Vector3.Distance(player.transform.position, thisItem.transform.position);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Dist < minDist)
            {
                Pickup();
            }
        }
    }
}
