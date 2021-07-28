using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemBase : MonoBehaviour, GrabItemIF
{
    protected bool being_grabed;
    protected bool grabable;
    protected Color init_color;
    protected Color highlight_color;

    protected virtual void Awake()
    {
        grabable = false;
        being_grabed = false;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
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

    public virtual void GrabableDehighlight()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Selected()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Deselected()
    {
        throw new System.NotImplementedException();
    }

    public virtual bool IsGrabable()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
