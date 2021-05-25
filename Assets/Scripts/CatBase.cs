using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for cat object;
/// </summary>
public class CatBase : MonoBehaviour
{
    [SerializeField] protected CatInfoBase catIB;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Parse_settings(GameSettingDataBase settings)
    {
        catIB.Parse_setting_data(settings);
    }
}
