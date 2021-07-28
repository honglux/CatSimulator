using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test scene reference controller;
/// </summary>
public class TSRC : IGRC
{
    public static TSRC TSIS;    //Test scene instance;

    public Transform Body_TRANS;
    public Transform Camera_TRANS;
    public ControllerInput right_CI;

    protected override void Awake()
    {
        TSIS = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
