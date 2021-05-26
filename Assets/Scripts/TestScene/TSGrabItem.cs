using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSGrabItem : GrabItemBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init_item()
    {
        ChangeBeingGrabedState(false);
        ChangeGrabableState(true);
    }

    public override void BeGrab()
    {
        ChangeBeingGrabedState(true);
        ChangeGrabableState(false);
    }

    public override void BeRelease()
    {
        ChangeBeingGrabedState(false);
        ChangeGrabableState(true);
    }

    public override void ChangeBeingGrabedState(bool _being_grabed)
    {
        being_grabed = _being_grabed;
    }

    public override void ChangeGrabableState(bool _grabable)
    {
        grabable = _grabable;
    }

    public override void GrabableHighlight()
    {
        throw new System.NotImplementedException();
    }
}
