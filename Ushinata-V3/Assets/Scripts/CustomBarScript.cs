using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class CustomBarScript : MonoBehaviour
{
    public float FillTime;
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        Reset();
    }

    public void Reset()
    {
        _slider.minValue = Time.time;
        _slider.maxValue = Time.time + FillTime;
    }
    void Update()
    {
        _slider.value = Time.time;
        if (_slider.value == FillTime)
        {
            Time.timeScale = 0;
            if (Time.timeScale == 0)
            {
                if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
                {
                    Reset();
                    Time.timeScale = 1;
                }
            }
        }
    }
}