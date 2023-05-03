using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //public GameObject player;
    [SerializeField] GameObject overworldObjects;

    public bool inOverworld = true;
    public bool needsEnemy = true;
    public string overworldSceneName;
    public GameObject player;
    public GameObject overworldPosition;
    public GameObject currentEnemy;
    public GameObject defaultEnemy;
    public GameObject playerUI;
    public GameObject freeLookCamera;
    public GameObject point;
    public GameObject castPoint;


    //move items and enemies under OverworldItemsAndEnemies in the heirarchy, create tag of the same name

    void Start()
    {
        //needsEnemy = true;
        currentEnemy = GameObject.Find("DefaultEnemy");
        overworldObjects = GameObject.FindGameObjectWithTag("OverworldItemsAndEnemies");
        playerUI = GameObject.Find("UI");
        player = GameObject.FindWithTag("Player"); 
        player.GetComponent<Animator>().enabled = false; 
        player.GetComponent<Animator>().enabled = true;
    }

    public void FindEnemy(GameObject enemy)
    {
        currentEnemy = enemy;
        inOverworld = false;
        //needsEnemy = false;
    }
    void Update()
    {
        if (needsEnemy == false && inOverworld == false)
        {
            if (currentEnemy.GetComponent<EnemyStats>().currentHealth <= 0)
            {
                needsEnemy = true;
                Debug.Log("dudes dead");
                //inOverworld = false;
                //currentEnemy.GetComponent<CombatTrans>().ReturnObjects();
                EnemyDefeated();
                needsEnemy = true;
                currentEnemy = null;
            }
        }
    }
    public void EnemyDefeated()
    {

        player = GameObject.FindWithTag("Player");
        //enemy = GameObject.FindWithTag("Enemy");
        overworldPosition = GameObject.Find("PlayerOverworldPosition");
        overworldSceneName = currentEnemy.GetComponent<CombatTrans>().overworldSceneName;
        Destroy(currentEnemy);
        player.transform.position = overworldPosition.transform.position;
        //SceneManager.LoadScene("StartingZone");
        //SceneManager.LoadScene(overworldSceneName);
        player.GetComponent<CombatMovementPlayer>().enabled = false;
        player.GetComponent<PlayerCardSystem>().enabled = false;
        player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        playerUI.transform.Find("PlayerUI").gameObject.SetActive(false);
        player.transform.Find("FreeLook Camera").gameObject.SetActive(true);
        player.transform.Find("CastPoint").gameObject.SetActive(false);
        //player.transform.Find("Point").gameObject.SetActive(false);



        EnableAll();
        Debug.Log("about to load scene");
        needsEnemy = true;
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(overworldSceneName);
        inOverworld = true;
        Debug.Log("loaded");
        //enemy = player.GetComponent<GameStart>().enemy;
        //if (currentEnemy.GetComponent<EnemyStats>().currentHealth <= 0 && SceneManager.GetActiveScene().name == "CombatScene2")
        //{


        //}
    }
    public void EnableAll()
    {

        for (int i = 0; i < overworldObjects.transform.childCount; i++)
        {
            overworldObjects.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DisableAll()
    {

        for (int i = 0; i < overworldObjects.transform.childCount; i++)
        {
            if (overworldObjects.transform.GetChild(i).gameObject.name.ToString() != currentEnemy.gameObject.name.ToString())
            {
                overworldObjects.transform.GetChild(i).gameObject.SetActive(false);

            }

        }
        currentEnemy.gameObject.SetActive(true);
    }
}