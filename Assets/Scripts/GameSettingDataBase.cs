using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

/// <summary>
/// Setting data for the game;
/// </summary>
public class GameSettingDataBase : MonoBehaviour
{
    public static GameSettingDataBase IS;

    [Header("Cat info")]
    public ValueWraperBase Health_VW; //Value wraper for sickness;
    public ValueWraperBase Hungry_VW;
    public ValueWraperBase Satis_VW;
    //Hardcoded enum lists, convert the index from value_wraper to actual state;
    public CatHealthState[] Health_itos;
    public CatHungryState[] Hungry_itos;
    public CatSatisState[] Satis_itos;

    protected virtual void Awake()
    {
        IS = this;
    }
}
