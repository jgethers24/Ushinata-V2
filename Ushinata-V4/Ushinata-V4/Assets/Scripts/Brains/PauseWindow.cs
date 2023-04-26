using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class PauseWindow : MonoBehaviour
{
    public float countDownTimer;
    public GameObject countDown;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countDown.gameObject.SetActive(true);
        if (countDown == true)
        {
            countDownTimer += Time.unscaledDeltaTime;
            if (countDownTimer >= 6f)
            {
                countDown.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
