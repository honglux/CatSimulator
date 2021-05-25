using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test scene game controller;
/// </summary>
public class TSGC : IGGC
{
    public static TSGC TSIS { get; private set; }   //TSGC instance;

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
