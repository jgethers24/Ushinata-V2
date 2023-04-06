using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrans : MonoBehaviour
{
    public string scenename;
    public GameObject player;
    public GameObject thisEnemy;
    public float EnemyDist;
    private float minEnDist = 3.0f;

    [SerializeField] private Transform playerSpawnPoint;
    

    //Transform startSpot;
    //Collider col;
    //Transform targetPoint;
    //public float speed = 1f;
    private void Start()
    {
        //col = player.GetComponent<CapsuleCollider>();
        //startSpot = GameObject.FindGameObjectWithTag("PlayerSpawnPoint").transform;
 
        //targetPoint.transform.Translate(0, 0, 1);
    }
    private void Update()
    {
        EnemyDist = Vector3.Distance(player.transform.position, thisEnemy.transform.position);
        if (EnemyDist < minEnDist)
        {
            //Vector3 target = new Vector3(startSpot.position.x, startSpot.position.y, startSpot.position.z);
            //Vector3 newPos = Vector3.MoveTowards(player.transform.position, target, speed * Time.deltaTime);
            //player.transform.Translate(newPos);
            //float distance = Vector3.Distance(target, rb.position);
            //player.(0, 0.63f, 3.87f);
            

            player.transform.position = playerSpawnPoint.transform.position;
            Physics.SyncTransforms();

            SceneManager.LoadScene(scenename);


            //combatSceneTransition();
        }
    }
}