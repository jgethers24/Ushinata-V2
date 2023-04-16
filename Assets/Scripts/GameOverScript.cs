using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    CharacterStats health;
    EnemyStats hp;

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
        health.currentHealth = 100;
        hp.currentHealth = 100;
    }

    public void QuitButton()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
