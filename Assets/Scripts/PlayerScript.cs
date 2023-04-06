using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] new string name;

    [TextArea]


    //Base Stats
    [SerializeField] int maxHp;
    [SerializeField] int strength;
    [SerializeField] int magic;
    [SerializeField] int speed;

    [SerializeField] List<MoveSet> moveSets;

    public string GetName()
    {
        return name;
    }
    public string Name
    {
        get { return name; }
    }
    public int MaxHp
    {
        get { return MaxHp; }
    }
    public string Strength
    {
        get { return Strength; }
    }
    public string Magic
    {
        get { return Magic; }
    }
    public string Speed
    {
        get { return Speed; }
    }
    public List<MoveSet> MoveSets
    {
        get { return moveSets; }
    }
}

