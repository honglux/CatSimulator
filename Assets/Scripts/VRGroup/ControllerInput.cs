using UnityEngine;
using UnityEngine.XR;
using System.Collections;

/// <summary>
/// Self implemented controller input script;
/// </summary>
public class ControllerInput : MonoBehaviour {

    //public OVRInput.Controller Controller_type;
    [SerializeField] private float joystickSensitivity = 0.5f;
    [SerializeField] private float triggerSensitivity = 0.5f;
    [SerializeField] private float grabSensitivity = 0.5f;
    [SerializeField] private bool usingXR;
    [SerializeField] private XRNode controller_node;

    public bool Forward_flag { get; set; }
    public bool Left_flag { get; set; }
    public bool Right_flag { get; set; }
    public bool Back_flag { get; set; }
    public bool Button_X_hold { get; set; }
    public bool Button_Y_hold { get; set; }
    public bool Index_trigger_holding { get; set; }
    public bool Grab_trigger_holding { get; set; }
    public float Joystick_x { get; set; }
    public float Joystick_y { get; set; }
    public System.Action Button_X { get; set; }
    public System.Action Button_Y { get; set; }
    public System.Action IndexTrigger { get; set; }
    public System.Action IndexTriggerRelease { get; set; }
    public System.Action GrabTrigger { get; set; }
    public System.Action GrabTriggerRelease { get; set; }
    public System.Action ForwardAction { get; set; }
    public System.Action LeftAction { get; set; }
    public System.Action RightAction { get; set; }
    public System.Action BackAction { get; set; }
    public System.Action<float> Joystick_x_update { get; set; }
    public System.Action<float> Joystick_y_update { get; set; }
    public System.Action<float> Joystick_x_fixupdate { get; set; }
    public System.Action<float> Joystick_y_fixupdate { get; set; }
    public System.Action<float, float> Joystick_xy_update { get; set; }
    public System.Action<float, float> Joystick_xy_fixupdate { get; set; }
    public System.Action<float, float> Joystick_xy_thresh_update { get; set; }
    public System.Action<float, float> Joystick_xy_thresh_fixupdate { get; set; }

    private bool index_triggered_flag;
    private bool xbutton_flag;
    private bool ybutton_flag;
    private InputDevice device;

    private void Awake()
    {
        this.Forward_flag = false;
        this.Back_flag = false;
        this.Right_flag = false;
        this.Left_flag = false;
        this.Index_trigger_holding = false;
        this.index_triggered_flag = false;
        this.Button_X_hold = false;
        this.Button_Y_hold = false;
        this.Button_X = null;
        this.Button_Y = null;
        this.IndexTrigger = null;
        this.IndexTriggerRelease = null;
        this.GrabTrigger = null;
        this.GrabTriggerRelease = null;
        this.ForwardAction = null;
        this.LeftAction = null;
        this.RightAction = null;
        this.BackAction = null;
        this.xbutton_flag = false;
        this.ybutton_flag = false;
        this.Joystick_x_update = null;
        this.Joystick_y_update = null;
        this.Joystick_xy_update = null;
        this.Joystick_x_fixupdate = null;
        this.Joystick_y_fixupdate = null;
        this.Joystick_xy_fixupdate = null;
        this.Joystick_xy_thresh_update = null;
        this.Joystick_xy_thresh_fixupdate = null;
        this.device = new InputDevice();
    }

    // Use this for initialization
    void Start () 
    {
        if (usingXR) { StartCoroutine(DelayedStart()); }
    }

    private IEnumerator DelayedStart()
    {
        yield return null;
        Get_XR_device();
    }

    private void Get_XR_device()
    {
        device = XRDeviceManager.Get_device(controller_node);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (usingXR) { Process_XR_controller(); }
        else { /*Other;*/ }
    }

    private void FixedUpdate()
    {
        Process_XR_controller_FU();
    }

    private void Process_XR_controller()
    {
        float trigger_val = 0.0f;
        float grab_val = 0.0f;
        float JS_horri_val = 0.0f;
        float JS_vert_val = 0.0f;
        bool buttonx = false;
        bool buttony = false;
        trigger_val = XRDeviceManager.Get_trigger_val(device);
        grab_val = XRDeviceManager.Get_grab_val(device);
        JS_horri_val = XRDeviceManager.Get_JS_horri(device);
        JS_vert_val = XRDeviceManager.Get_JS_vert(device);
        buttonx = XRDeviceManager.Get_xbutton(device);
        buttony = XRDeviceManager.Get_ybutton(device);

        Process_trigger(trigger_val);
        Process_grab(grab_val);
        Process_JS(new Vector2(JS_horri_val, JS_vert_val));
        Process_buttons((buttonx, buttony));
    }

    private void Process_trigger(float val)
    {
        if (val > triggerSensitivity)
        {
            if (!Index_trigger_holding && IndexTrigger != null)
            { IndexTrigger(); }
            Index_trigger_holding = true;
        }
        else
        {
            if (Index_trigger_holding && IndexTriggerRelease != null)
            { IndexTriggerRelease(); }
            Index_trigger_holding = false;
        }
    }

    private void Process_grab(float val)
    {
        if (val > grabSensitivity)
        {
            if (!Grab_trigger_holding && GrabTrigger != null)
            { GrabTrigger(); }
            Grab_trigger_holding = true;
        }
        else
        {
            if (Grab_trigger_holding && GrabTriggerRelease != null)
            { GrabTriggerRelease(); }
            Grab_trigger_holding = false;
        }
    }

    /// <summary>
    /// Jotstick;
    /// </summary>
    /// <param name="axis2d">Horizontal then vertical</param>
    private void Process_JS(Vector2 axis2d)
    {
        Process_JS_horri(axis2d.x);
        Process_JS_vert(axis2d.y);
        Process_JS_diagonal(axis2d.x, axis2d.y);
    }

    private void Process_JS_horri(float val)
    {
        Joystick_x = val;
        if (val > joystickSensitivity)
        {
            if (!Right_flag && RightAction != null)
            {
                RightAction();
            }
            Right_flag = true;
        }
        else
        {
            Right_flag = false;
        }
        if (val < -joystickSensitivity)
        {
            if (!Left_flag && LeftAction != null)
            {
                LeftAction();
            }
            Left_flag = true;
        }
        else
        {
            Left_flag = false;
        }

        if (Joystick_x_update != null) { Joystick_x_update(val); }
    }

    private void Process_JS_vert(float val)
    {
        Joystick_y = val;
        if (val > joystickSensitivity)
        {
            if (!Forward_flag && ForwardAction != null)
            {
                ForwardAction();
            }
            Forward_flag = true;
        }
        else
        {
            Forward_flag = false;
        }
        if (val < -joystickSensitivity)
        {
            if (!Back_flag && BackAction != null)
            {
                BackAction();
            }
            Back_flag = true;
        }
        else
        {
            Back_flag = false;
        }

        if (Joystick_y_update != null) { Joystick_y_update(val); }
    }

    private void Process_JS_diagonal(float xval, float yval)
    {
        if (Joystick_xy_update != null) { Joystick_xy_update(xval, yval); }
        if (Joystick_xy_thresh_update != null && ((xval * xval) + (yval * yval) >= joystickSensitivity))
        { Joystick_xy_thresh_update(xval, yval); }
    }

    /// <summary>
    /// Process buttons;
    /// </summary>
    /// <param name="but_bools">x button then y button</param>
    private void Process_buttons((bool,bool) but_bools)
    {
        Process_xbutton(but_bools.Item1);
        Process_ybutton(but_bools.Item2);
    }

    private void Process_xbutton(bool but_bool)
    {
        Button_X_hold = but_bool;
        if (but_bool && !xbutton_flag && Button_X != null)
        {
            Button_X();
        }
        xbutton_flag = but_bool;
    }

    private void Process_ybutton(bool but_bool)
    {
        Button_Y_hold = but_bool;
        if (but_bool && !ybutton_flag && Button_Y != null)
        {
            Button_Y();
        }
        ybutton_flag = but_bool;
    }

    private void Process_XR_controller_FU()
    {
        Process_JS_FU(new Vector2(Joystick_x, Joystick_y));
    }

    private void Process_JS_FU(Vector2 axis2d)
    {
        Process_JS_horr_FU(axis2d.x);
        Process_JS_vert_FU(axis2d.y);
        Process_JS_diag_FU(axis2d.x, axis2d.y);
    }

    private void Process_JS_horr_FU(float val)
    {
        if (Joystick_x_fixupdate != null) { Joystick_x_fixupdate(val); }
    }

    private void Process_JS_vert_FU(float val)
    {
        if (Joystick_y_fixupdate != null) { Joystick_y_fixupdate(val); }
    }

    private void Process_JS_diag_FU(float xval, float yval)
    {
        if (Joystick_xy_fixupdate != null) { Joystick_xy_fixupdate(xval, yval); }
        if (Joystick_xy_thresh_fixupdate != null && ((xval * xval) + (yval * yval) >= joystickSensitivity))
        { Joystick_xy_thresh_fixupdate(xval, yval); }
    }

    public void Clear_Actions()
    {
        Forward_flag = false;
        Back_flag = false;
        Right_flag = false;
        Left_flag = false;
        Index_trigger_holding = false;
        index_triggered_flag = false;
        Button_X_hold = false;
        Button_Y_hold = false;
        Button_X = null;
        Button_Y = null;
        IndexTrigger = null;
        IndexTriggerRelease = null;
        ForwardAction = null;
        LeftAction = null;
        RightAction = null;
        BackAction = null;
        xbutton_flag = false;
        ybutton_flag = false;
        Joystick_x_update = null;
        Joystick_y_update = null;
        Joystick_xy_update = null;
        Joystick_x_fixupdate = null;
        Joystick_y_fixupdate = null;
        Joystick_xy_fixupdate = null;
        Joystick_xy_thresh_update = null;
        Joystick_xy_thresh_fixupdate = null;
    }
}