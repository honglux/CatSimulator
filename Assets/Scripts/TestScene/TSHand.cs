using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint))]
public class TSHand : HandBase
{
    // Start is called before the first frame update
    protected override void Start()
    {
        Init_hand();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void Init_hand()
    {
        Bind_grab_button();
        Bind_grab_release_button();
        Bind_y_button();

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

    public override void Grab()
    {
        if (grab_target_TRANS == null) { return; }
        Grab(grab_target_TRANS);
    }

    public override void Grab(Transform other_TRANS)
    {
        GrabItemIF item = null;
        if (able_to_grab && other_TRANS.TryGetComponent<GrabItemIF>(out item) && item.IsGrabable())
        {
            GrabHandImplmentation.Grab_with_joint(GetComponent<FixedJoint>(),
                other_TRANS.GetComponent<Rigidbody>());
            item.BeGrab();
            ChangeGrabingState(true);
            ChangeAbleGrabState(false);
        }
    }

    public override void UnGrab()
    {
        if(is_grabing)
        {
            GrabHandImplmentation.UnGrab_joint(GetComponent<FixedJoint>());
            ChangeGrabingState(false);
            ChangeAbleGrabState(true);
            Release_last(grab_target_TRANS);
        }
    }

    private void Release_last(Transform last_TRANS)
    {
        GrabItemIF item = null;
        if(last_TRANS != null && last_TRANS.TryGetComponent<GrabItemIF>(out item))
        {
            item.BeRelease();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(SD.GrabableItemTag))
        {
            other.GetComponent<GrabItemIF>().Selected();
            grab_target_TRANS = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SD.GrabableItemTag))
        {
            other.GetComponent<GrabItemIF>().Deselected();
            //grab_target_TRANS = null;
        }
    }

    private void Bind_grab_button()
    {
        TSRC.TSIS.right_CI.GrabTrigger += Grab;
    }

    private void Bind_grab_release_button()
    {
        TSRC.TSIS.right_CI.GrabTriggerRelease += UnGrab;
    }

    private void Unbind_grab_button()
    {
        TSRC.TSIS.right_CI.GrabTrigger -= Grab;
    }

    private void Unbind_grab_release_button()
    {
        TSRC.TSIS.right_CI.GrabTriggerRelease -= UnGrab;
    }

    private void Bind_y_button()
    {
        TSRC.TSIS.right_CI.Button_Y += XRController.IS.RecenterVRPosition;
    }

    private void Unbind_y_button()
    {
        TSRC.TSIS.right_CI.Button_Y -= XRController.IS.RecenterVRPosition;
    }

    private void OnDestroy()
    {
        Unbind_grab_button();
        Unbind_grab_release_button();
        Unbind_y_button();
    }
}
