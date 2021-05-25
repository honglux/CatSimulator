using UnityEngine;

/// <summary>
/// In game scene game settings;
/// </summary>
public class IGGS : MonoBehaviour
{
    public static IGGS IGIS;    //In game scene instance;

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

    protected virtual void Parse_cat_info()
    {

    }

    #region public methods;

    public virtual void FirstOnLoad()
    {
        Parse_cat_info();
    }

    #endregion
}
