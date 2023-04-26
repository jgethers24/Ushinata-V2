using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalkerDataEntry
{
    public int TalkerId;
    public string TalkerName;
    public string TalkerText;
}

[System.Serializable]
public class TalkerDataJSON
{
    public TalkerDataEntry[] Talkers;
}
    
public class DialogueDatabase : MonoBehaviour
{
    public TextAsset MyJsonData;
    TalkerDataJSON MyTalkerData;

    void Start()
    {
        string json = MyJsonData.text;
        MyTalkerData = JsonUtility.FromJson<TalkerDataJSON>(json);
    }

    public string GetTalkerName(int talkerId)
    {
        for(int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if(MyTalkerData.Talkers[i].TalkerId == talkerId)
            {
                return MyTalkerData.Talkers[i].TalkerName;
            }
        }
        return "[NO_NAME_FOUND]";
    }

    public string GetTalkerText(int talkerId)
    {
        for (int i = 0; i < MyTalkerData.Talkers.Length; ++i)
        {
            if (MyTalkerData.Talkers[i].TalkerId == talkerId)
            {
                return MyTalkerData.Talkers[i].TalkerText;
            }
        }
        return "[NO_TEXT_FOUND]";
    }
}
