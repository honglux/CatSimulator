using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSGrabItem : GrabItemBase
{
    [SerializeField] private Color _init_color;
    [SerializeField] private Color _highlight_color;

    protected override void Awake()
    {
        base.Awake();
        init_color = _init_color;
        highlight_color = _highlight_color;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        Init_item();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void Init_item()
    {
        ChangeBeingGrabedState(false);
        ChangeGrabableState(true);
    }

    public override void BeGrab()
    {
        Debug.Log("BeGrab");
        GetComponent<Rigidbody>().useGravity = false;
        ChangeBeingGrabedState(true);
        ChangeGrabableState(false);
    }

    public override void BeRelease()
    {
        Debug.Log("BeRelease");
        GetComponent<Rigidbody>().useGravity = true;
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
        GetComponent<MeshRenderer>().material.color = highlight_color;
    }

    public override void GrabableDehighlight()
    {
        GetComponent<MeshRenderer>().material.color = init_color;
    }

    public override void Selected()
    {
        GrabableHighlight();
    }

    public override void Deselected()
    {
        GrabableDehighlight();
    }

    public override bool IsGrabable()
    {
        return grabable;
    }
}
