using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class CustomBarScript : MonoBehaviour
{
    public float FillTime;
    private Slider _slider;
    public bool fullBar;

    void Start()
    {
        fullBar = false;
        _slider = GetComponent<Slider>();
        Reset();
    }

    public void Reset()
    {
        fullBar = false;
        _slider.minValue = Time.time;
        _slider.maxValue = Time.time + FillTime;
    }
    void Update()
    {
        if (GameObject.Find("InventoryCanvas").GetComponent<InvenManager>().CombatCardMenu.activeSelf==true)
        {
            Time.timeScale = 0;
        }
        if(fullBar == false)
        {
            _slider.value = Time.time;
        }
        
        if (_slider.value >= _slider.maxValue)
        {
            fullBar = true;
            //Time.timeScale = 0;
            /*Time.timeScale = 0;
            if (Time.timeScale == 0)
            {
                if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
                {
                    Reset();
                    Time.timeScale = 1;
                }
            }*/
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
}