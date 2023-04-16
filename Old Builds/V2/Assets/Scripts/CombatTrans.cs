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

    public GameObject freeLookCamera;
    public GameObject point;
    public GameObject castPoint;


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
            


            player.transform.position = playerSpawnPoint.transform.position;
            Physics.SyncTransforms();

            SceneManager.LoadScene(scenename);
            Time.timeScale = 1;
            player.GetComponent<CombatMovementPlayer>().enabled = true;
            player.GetComponent<PlayerCardSystem>().enabled = true;
            player.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
            //player.GetComponent<StarterAssets.StarterAssetsInputs>().enabled = false;
            //player.GetComponent<BasicRigidBodyPush>().enabled = false;
            freeLookCamera.SetActive(false);
            point.SetActive(true);
            castPoint.SetActive(true);
            player.SetActive(false);
            player.SetActive(true);

            //combatSceneTransition();
        }
    }
}