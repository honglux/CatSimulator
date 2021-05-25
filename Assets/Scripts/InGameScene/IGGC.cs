using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In game game controller; Controller for "In game scene";
/// </summary>
public class IGGC : MonoBehaviour
{
    public static IGGC IGIS { get; private set; }    //IGGC instance;

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
