using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //public GameObject player;
    
    //public bool inOverworld;
    public bool needsEnemy;
    public string overworldSceneName;
    public GameObject player;
    public GameObject overworldPosition;
    public GameObject currentEnemy;

    public GameObject freeLookCamera;
    public GameObject point;
    public GameObject castPoint;

    
    void Start()
    {
        //inOverworld = true;
        needsEnemy = true;
        //currentEnemy = null;

    }
    //void OnCollisionEnter(Collision collision)
    //{
    //   if (collision.gameObject.tag =="Enemy")
    //  {
    //     enemy = collision.gameObject;
    //}
    //}
    // Update is called once per frame
    public void FindEnemy(GameObject enemy)
    {
        currentEnemy = enemy;
        needsEnemy = false;
    }
    void Update()
    {
        if(needsEnemy == false)
        {
            if (currentEnemy.GetComponent<EnemyStats>().currentHealth <= 0)
            {
                Debug.Log("dudes dead");
                //inOverworld = false;
                //currentEnemy.GetComponent<CombatTrans>().ReturnObjects();
                EnemyDefeated();
                currentEnemy = null;
            }
        }

        /*if(inOverworld == false)
        {
            GameObject[] objs;
            GameObject[] foes;
            objs = GameObject.FindGameObjectsWithTag("Item");
            foes = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject item in objs)
            {
                item.SetActive(true);
            }
            foreach (GameObject allEnemies in foes)
            {
                allEnemies.SetActive(true);
            }
    }*/
    }
    public void EnemyDefeated()
    {
        
        player = GameObject.FindWithTag("Player");
        //enemy = GameObject.FindWithTag("Enemy");
        overworldPosition = GameObject.Find("PlayerOverworldPosition");
        overworldSceneName = currentEnemy.GetComponent<CombatTrans>().overworldSceneName;

        player.transform.position = overworldPosition.transform.position;
        //SceneManager.LoadScene("StartingZone");
        //SceneManager.LoadScene(overworldSceneName);
        player.GetComponent<CombatMovementPlayer>().enabled = false;
        player.GetComponent<PlayerCardSystem>().enabled = false;
        player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
        player.GetComponent<Animator>().enabled = true;

        player.transform.Find("FreeLook Camera").gameObject.SetActive(true);
        player.transform.Find("CastPoint").gameObject.SetActive(false);
        //player.transform.Find("Point").gameObject.SetActive(false);


        Destroy(currentEnemy);
        Debug.Log("about to load scene");
        needsEnemy = true;
        SceneManager.LoadScene(0);
        //enemy = player.GetComponent<GameStart>().enemy;
        //if (currentEnemy.GetComponent<EnemyStats>().currentHealth <= 0 && SceneManager.GetActiveScene().name == "CombatScene2")
        //{


        //}
    }
}