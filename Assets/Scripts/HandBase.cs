using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBase : MonoBehaviour, GrabHandIF
{

    protected bool able_to_grab;
    protected bool is_grabing;

    private void Awake()
    {
        able_to_grab = false;
        is_grabing = false;
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

    public virtual void Init_hand()
    {
        throw new System.NotImplementedException();
    }

    public virtual void ChangeAbleGrabState(bool _able_to_grab)
    {
        throw new System.NotImplementedException();
    }

    public virtual void ChangeGrabingState(bool _is_grabing)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Grab(Transform other_TRANS)
    {
        throw new System.NotImplementedException();
    }

    public virtual void UnGrab()
    {
        throw new System.NotImplementedException();
    }

    #endregion

}
