using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public static Currency instance;
    public int baseMoney;
    public int money;
    public void Start()
    {
        money = baseMoney;
        instance = this;
    }
    public int ChangeMoney(int amountToChangeMoney)
    {

    Debug.Log("monmey " + amountToChangeMoney);
    instance.money += amountToChangeMoney;
    Debug.Log("XXXXXXXXXXX");
    return instance.money;
}
}
