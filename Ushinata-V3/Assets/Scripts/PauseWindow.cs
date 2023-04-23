using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class PauseWindow : MonoBehaviour
{
    public GameObject Bar;
    public float pauseTimer;
    public float gameStartCountdown;
    // Start is called before the first frame update
    void Start()
    {
        animateBar();
    }

    // Update is called once per frame
    void Update()
    {
        pauseTimer += Time.deltaTime;
        if (pauseTimer >= 10)
        {
            Time.timeScale = 0;
            if (Time.timeScale == 0)
            {
                if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
                {
                    pauseTimer = 0;
                    Time.timeScale = 1;
                    Debug.Log("Time");
                }
            }
        }
    }

    public void animateBar()
    {
        LeanTween.scaleY(Bar, 1, pauseTimer).setOnComplete(resetBar);
    }

    public void resetBar()
    {
        LeanTween.scaleY(Bar, 0, 0).setOnComplete(animateBar);
    }
}
