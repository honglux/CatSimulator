using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemBase : MonoBehaviour, GrabItemIF
{

    protected bool being_grabed;
    protected bool grabable;

    private void Awake()
    {
        grabable = false;
        being_grabed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region public methods;

    public virtual void Init_item()
    {
        throw new System.NotImplementedException();
    }

    public virtual void BeGrab()
    {
        throw new System.NotImplementedException();
    }

    public virtual void BeRelease()
    {
        throw new System.NotImplementedException();
    }

    public virtual void ChangeBeingGrabedState(bool _being_grabed)
    {
        throw new System.NotImplementedException();
    }

    public virtual void ChangeGrabableState(bool _grabable)
    {
        throw new System.NotImplementedException();
    }

    public virtual void GrabableHighlight()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
