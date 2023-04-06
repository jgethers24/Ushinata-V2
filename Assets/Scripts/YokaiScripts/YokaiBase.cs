using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Yokai", menuName = "Yokai/Create new Yokai")]
public class YokaiBase : ScriptableObject
{
   
    
    [SerializeField] new string name;

    [TextArea]

    [SerializeField] Object Object;
    [SerializeField] Object @object;
    [SerializeField] GameObject GameObject;
    [SerializeField] GameObject gameObject;

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
        get { return MaxHp;  }
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
[System.Serializable]
public class MoveSet
{
    [SerializeField] MoveBase moveBase;
    
    public MoveBase Base
        {
        get { return moveBase; }
        }

}
