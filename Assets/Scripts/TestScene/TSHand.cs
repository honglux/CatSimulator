using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint))]
public class TSHand : HandBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init_hand()
    {
        ChangeAbleGrabState(true);
        ChangeGrabingState(false);
    }

    public override void ChangeAbleGrabState(bool _able_to_grab)
    {
        able_to_grab = _able_to_grab;
    }

    public override void ChangeGrabingState(bool _is_grabing)
    {
        is_grabing = _is_grabing;
    }

    public override void Grab(Transform other_TRANS)
    {
        GrabHandImplmentation.Grab_with_joint(GetComponent<FixedJoint>(), 
            other_TRANS.GetComponent<Rigidbody>());
        ChangeGrabingState(true);
        ChangeAbleGrabState(false);
    }

    public override void UnGrab()
    {
        GrabHandImplmentation.UnGrab_joint(GetComponent<FixedJoint>());
        ChangeGrabingState(false);
        ChangeAbleGrabState(true);
    }
}
