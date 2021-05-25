using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test scene game settings;
/// </summary>
public class TSGS : IGGS
{
    public static TSGS TSIS;    //Test scene instance;

    protected override void Awake()
    {
        TSIS = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        Parse_cat_info();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void Parse_cat_info()
    {
        TSRC.TSIS.Cat_TRANS.GetComponent<CatBase>().Parse_settings(GameSettingDataBase.IS);
    }
}
