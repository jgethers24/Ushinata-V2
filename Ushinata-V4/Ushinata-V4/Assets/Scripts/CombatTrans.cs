using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrans : MonoBehaviour
{
    public bool canTeleport = true;
    public string scenename;
    public string overworldSceneName;
    private GameObject player;
    public GameObject thisEnemy;
    public GameObject overworldPosition;
    public float EnemyDist;
    private float minEnDist = 3.0f;

    public GameObject freeLookCamera;
    //public GameObject point;
    public GameObject castPoint;


    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform enemySpawnPoint;





    private void Start()
    {
        //canTeleport = true;
        //Debug.Log("stupid ass canteleport is true");
        player = GameObject.FindWithTag("Player");
        thisEnemy = this.gameObject;
        overworldPosition = GameObject.Find("PlayerOverworldPosition");

    }
    private void Update()
    {
        //if (combatGameManager==null)
        //{
        //   combatGameManager = GameObject.Find("CombatGameManager");
        //  combatGameManager.GetComponent<EnemyDefeated>().SetEnemy();
        //}
        /*
                if (thisEnemy.GetComponent<EnemyStats>().currentHealth <= 0 || thisEnemy == null)
                {
                    foreach (GameObject item in objs)
                    {
                        item.SetActive(true);
                    }
                    foreach (GameObject allEnemies in foes)
                    {
                        allEnemies.SetActive(true);
                    }
                }
        */
        Vector3 playerPos = player.transform.position;
        EnemyDist = Vector3.Distance(player.transform.position, thisEnemy.transform.position);
        if (EnemyDist < minEnDist && canTeleport == true)
        {
            overworldPosition.transform.position = player.transform.position;
            overworldPosition.transform.position = new Vector3(overworldPosition.transform.position.x, overworldPosition.transform.position.y + 1, overworldPosition.transform.position.z);


            player.transform.rotation = Quaternion.identity;
            player.transform.position = playerSpawnPoint.transform.position;
            thisEnemy.transform.rotation = Quaternion.identity;
            thisEnemy.transform.position = enemySpawnPoint.transform.position;
            GameObject.DontDestroyOnLoad(thisEnemy);
            //this.GetComponent<DontDestroy>().enabled = true;
            thisEnemy.GetComponent<DummyKaiAI>().enabled = true;

            player.transform.GetComponent<GameStart>().FindEnemy(thisEnemy);
            player.GetComponent<GameStart>().needsEnemy = false;

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


            Debug.LogWarning("abc");
            player.GetComponent<GameStart>().DisableAll();
            Debug.LogWarning("123");

            player.SetActive(false);
            player.SetActive(true);
            player.GetComponent<Animator>().enabled = true;

            thisEnemy.gameObject.SetActive(true);
            thisEnemy = player.GetComponent<GameStart>().currentEnemy;
            thisEnemy.SetActive(true);
            thisEnemy.gameObject.SetActive(true);
            canTeleport = false;

        }
    }

}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrans : MonoBehaviour
{
    public bool canTeleport;
    public string scenename;
    public string overworldSceneName;
    private GameObject player;
    public GameObject thisEnemy;
    public GameObject overworldPosition;
    public float EnemyDist;
    private float minEnDist = 3.0f;

    public GameObject freeLookCamera;
    //public GameObject point;
    public GameObject castPoint;


    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform enemySpawnPoint;

   
    
    

    private void Start()
    {
        canTeleport = true;
        player = GameObject.FindWithTag("Player");
        thisEnemy = this.gameObject;
        overworldPosition = GameObject.Find("PlayerOverworldPosition");
        
    }
    private void Update()
    {
        //if (combatGameManager==null)
        //{
         //   combatGameManager = GameObject.Find("CombatGameManager");
          //  combatGameManager.GetComponent<EnemyDefeated>().SetEnemy();
        //}
/*
        if (thisEnemy.GetComponent<EnemyStats>().currentHealth <= 0 || thisEnemy == null)
        {
            foreach (GameObject item in objs)
            {
                item.SetActive(true);
            }
            foreach (GameObject allEnemies in foes)
            {
                allEnemies.SetActive(true);
            }
        }

        Vector3 playerPos = player.transform.position;
        EnemyDist = Vector3.Distance(player.transform.position, thisEnemy.transform.position);
        if (EnemyDist < minEnDist && canTeleport == true)
        {
            overworldPosition.transform.position = player.transform.position;
            player.transform.rotation = Quaternion.identity;
            player.transform.position = playerSpawnPoint.transform.position;
            thisEnemy.transform.rotation = Quaternion.identity;
            thisEnemy.transform.position = enemySpawnPoint.transform.position;
            GameObject.DontDestroyOnLoad(thisEnemy);
            //this.GetComponent<DontDestroy>().enabled = true;
            thisEnemy.GetComponent<DummyKaiAI>().enabled = true;
            
            player.transform.GetComponent<GameStart>().FindEnemy(thisEnemy);
            
            
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

            //combatGameManager.GetComponent<EnemyDefeated>().thenemy = thisEnemy;
            //if (combatGameManager == null)
            //{
            //    combatGameManager = GameObject.Find("CombatGameManager");
            //    combatGameManager.GetComponent<EnemyDefeated>().SetEnemy();
            //}
            GameObject[] objs;
            objs = GameObject.FindGameObjectsWithTag("Item");
            GameObject[] foes;
            foes = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject item in objs)
            {
                item.SetActive(false);
            }
            foreach (GameObject allEnemies in foes)
            {
                allEnemies.SetActive(false);
            }
            
            player.SetActive(false);
            player.SetActive(true);
            player.GetComponent<Animator>().enabled = true;

            thisEnemy.SetActive(true);
            thisEnemy = player.GetComponent<GameStart>().currentEnemy;
            thisEnemy.SetActive(true);
            canTeleport = false;

        }
    }
    
    public void ReturnObjects()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] foes;
        foes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in objs)
        {
            item.SetActive(true);
        }
        foreach (GameObject allEnemies in foes)
        {
            allEnemies.SetActive(true);
        }
    }
    
}
*/