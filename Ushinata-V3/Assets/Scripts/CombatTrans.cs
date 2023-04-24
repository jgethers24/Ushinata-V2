using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrans : MonoBehaviour
{
    public string scenename;
    private GameObject player;
    public GameObject thisEnemy;
    public float EnemyDist;
    private float minEnDist = 3.0f;

    public GameObject freeLookCamera;
    public GameObject point;
    public GameObject castPoint;


    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform enemySpawnPoint;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        thisEnemy = this.gameObject;
    }
    private void Update()
    {
        
        Vector3 playerPos = player.transform.position;
        EnemyDist = Vector3.Distance(player.transform.position, thisEnemy.transform.position);
        if (EnemyDist < minEnDist)
        {
            player.transform.rotation = Quaternion.identity;
            player.transform.position = playerSpawnPoint.transform.position;
            thisEnemy.transform.rotation = Quaternion.identity;
            thisEnemy.transform.position = enemySpawnPoint.transform.position;
            GameObject.DontDestroyOnLoad(thisEnemy.gameObject);
            //this.GetComponent<DontDestroy>().enabled = true;
            thisEnemy.GetComponent<DummyKaiAI>().enabled = true;

            
            Physics.SyncTransforms();

            SceneManager.LoadScene(scenename);
            Time.timeScale = 1;
            player.GetComponent<CombatMovementPlayer>().enabled = true;
            player.GetComponent<PlayerCardSystem>().enabled = true;
            player.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            
            player.transform.Find("FreeLook Camera").gameObject.SetActive(false);
            player.transform.Find("CastPoint").gameObject.SetActive(true);
            player.transform.Find("Point").gameObject.SetActive(true);


            

            player.SetActive(false);
            player.SetActive(true);
            player.GetComponent<Animator>().enabled = true;
        }
    }
}