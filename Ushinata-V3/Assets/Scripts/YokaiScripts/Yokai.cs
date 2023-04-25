using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokai : MonoBehaviour
{
    public YokaiBase yokaiBase;
    //YokaiBase _base;
    public int HP { get; set; }

    public List<Move> Moves {get;set;}

    public Yokai(YokaiBase pBase)
    {
        yokaiBase = pBase;
        HP = yokaiBase.MaxHp;

        Moves = new List<Move>();
        foreach(var move in yokaiBase.MoveSets)
        {
            Moves.Add(new Move(move.Base));
        }
    }
    /*public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }*/

}
