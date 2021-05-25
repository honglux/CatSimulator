using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;
using System;

/// <summary>
/// Base class to store runtime cat info;
/// </summary>
public class CatInfoBase : MonoBehaviour
{
    public CatMovingState MovingState { get; set; }
    public CatHealthState HealthState { get; set; }
    public CatHungryState HungryState { get; set; }
    public CatSatisState SatisState { get; set; }

    protected float satis_val;
    protected float health_val;
    protected float hungry_val;
    protected ValueWraperBase satis_VW; //Value wraper class;
    protected ValueWraperBase health_VW;
    protected ValueWraperBase hungry_VW;
    protected CatHealthState[] health_itos; //Value index to state dictionary;
    protected CatHungryState[] hungry_itos;
    protected CatSatisState[] satis_itos;

    private void Awake()
    {
        MovingState = default(CatMovingState);
        HealthState = default(CatHealthState);
        HungryState = default(CatHungryState);
        SatisState = default(CatSatisState);

        health_val = 0.0f;
        hungry_val = 0.0f;
        satis_val = 0.0f;
        satis_VW = null;
        health_VW = null;
        hungry_VW = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Init_values()
    {
        satis_val = satis_VW.Init_val;
        SatisState = (CatSatisState)Get_curr_satis_state();
        hungry_val = hungry_VW.Init_val;
        HungryState = (CatHungryState)Get_curr_hungry_state();
        health_val = health_VW.Init_val;
        HealthState = (CatHealthState)Get_curr_health_state();
    }

    #region public methods;

    public void Parse_setting_data(GameSettingDataBase data)
    {
        satis_VW = data.Satis_VW;
        hungry_VW = data.Hungry_VW;
        health_VW = data.Health_VW;
        satis_itos = data.Satis_itos;
        hungry_itos = data.Hungry_itos;
        health_itos = data.Health_itos;

        Init_catinfo();
    }

    public void Init_catinfo()
    {
        Init_values();
    }

    public int Get_curr_health_state()
    {
        int val_index = health_VW.State_index_cal(health_val);
        return Utilities.State_index_cal<CatHealthState>(health_itos, val_index);
    }

    public int Get_curr_hungry_state()
    {
        int val_index = hungry_VW.State_index_cal(hungry_val);
        return Utilities.State_index_cal<CatHungryState>(hungry_itos, val_index);
    }

    public int Get_curr_satis_state()
    {
        int val_index = satis_VW.State_index_cal(satis_val);
        return Utilities.State_index_cal<CatSatisState>(satis_itos, val_index);
    }

    #endregion
}
