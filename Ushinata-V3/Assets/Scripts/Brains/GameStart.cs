using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //public GameObject player;
    
    public bool inOverworld;

    public string overworldSceneName;
    public GameObject player;
    public GameObject overworldPosition;
    public GameObject enemy;

    public GameObject freeLookCamera;
    public GameObject point;
    public GameObject castPoint;

    GameObject gamemanager;
    void Start()
    {
        inOverworld = true;
        

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            enemy = collision.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(inOverworld == false)
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
        }  
    }
    public void EnemyDefeated()
    {
        gamemanager = GameObject.Find("Game Manager");
        player = GameObject.FindWithTag("Player");
        //enemy = GameObject.FindWithTag("Enemy");
        overworldPosition = GameObject.Find("PlayerOverworldPosition");
        overworldSceneName = enemy.GetComponent<CombatTrans>().overworldSceneName;

        //enemy = player.GetComponent<GameStart>().enemy;
        if (enemy.GetComponent<EnemyStats>().currentHealth <= 0 && SceneManager.GetActiveScene().name == "CombatScene2")
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

            gamemanager.GetComponent<GameStart>().inOverworld = false;
            SceneManager.LoadScene(0);

        }
    }
}