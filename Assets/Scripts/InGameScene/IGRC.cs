using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In game scene reference controller;
/// </summary>
public class IGRC : MonoBehaviour
{
    public static IGRC IGIS;    //In game scene isntance;

    public Transform Cat_TRANS;

    protected virtual void Awake()
    {
        IGIS = this;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
