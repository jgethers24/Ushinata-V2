using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartButton()
    {
        //GameObject.DontDestroyOnLoad(null);
        SceneManager.LoadScene(0);
        CharacterStats characterStats = GameObject.FindWithTag("Player").GetComponent<CharacterStats>();
        characterStats.currentHealth = 100;
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
