using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameControl : MonoBehaviour
{
    //public int Pickupcount;
    public int Pickup1state;
    public int Pickup2state;
    public static GameControl control;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(20, 20, 200, 30), "Level code count: " + Pickupcount);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        //data.Pickupcount = Pickupcount;
        data.Pickup1state = Pickup1state;
        data.Pickup2state = Pickup2state;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Pickupcount = data.Pickupcount;
            Pickup1state = data.Pickup1state;
            Pickup2state = data.Pickup2state;
        }
    }
}

[Serializable]
class PlayerData
{
    public int Pickupcount;
    public int Pickup1state;
    public int Pickup2state;
}