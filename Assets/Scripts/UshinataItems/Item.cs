using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//item pickup
public class Item : MonoBehaviour
{
    public ItemSO itemSo;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;
    [TextArea]
    [SerializeField]
    private string itemDescription;
    
   
    public GameObject itemObject;
    public GameObject player;
    public float Dist;
    private float minDist = 2.0f;

    private InvenManager invenManager;

    public ItemType itemType;

    // Start is called before the first frame update
    void Start()
    {
        invenManager = GameObject.Find("InventoryCanvas").GetComponent<InvenManager>();
    }
    void Update()
    {
        Dist = Vector3.Distance(player.transform.position, itemObject.transform.position);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Dist < minDist)
            {
                int leftOverItems = invenManager.AddItem(itemName, quantity, sprite, itemDescription,itemType, itemObject);//object ref
                if (leftOverItems <= 0)
                {
                    Debug.Log("Picking up " + itemName);
                    Destroy(gameObject);
                }
                else
                {
                    quantity = leftOverItems;
                }
            }
        }
    }
}
