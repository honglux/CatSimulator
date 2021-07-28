using UnityEngine.XR;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class XRDeviceManager
{
    public static InputDevice HeadNode { get; set; }
    public static InputDevice LeftControllerNode { get; set; }
    public static InputDevice RightControllerNode { get; set; }
    public static XRInputSubsystem Subsystem { get; set; }
    public static bool Inited { get; set; } = false;

    public static void InitXRDevice()
    {
        if (Inited) { return; }
        HeadNode = Init_device(XRNode.Head);
        LeftControllerNode = Init_device(XRNode.LeftHand);
        RightControllerNode = Init_device(XRNode.RightHand);
        Subsystem = Get_subsys();

        Inited = true;
    }

    public static void UpdateXRDevice()
    {
        Inited = false;
        InitXRDevice();
    }

    private static InputDevice Init_device(UnityEngine.XR.XRNode node)
    {
        var devices = new List<UnityEngine.XR.InputDevice>();
        try { UnityEngine.XR.InputDevices.GetDevicesAtXRNode(node, devices); }
        catch (Exception e) { Debug.LogError("GetDevicesAtXRNode Error! " + e); }


        if (devices.Count == 1)
        {
            Debug.Log(string.Format("Device name '{0}' with role '{1}'",
                devices[0].name, devices[0].characteristics.ToString()));
            return devices[0];
        }
        else if (devices.Count > 1)
        {
            Debug.LogError(string.Format("Found more than one node from '{0}'!", node.ToString()));
        }
        return new InputDevice();
    }

    private static XRInputSubsystem Get_subsys()
    {
        List<XRInputSubsystem> xISs = new List<XRInputSubsystem>();
        try { SubsystemManager.GetInstances<XRInputSubsystem>(xISs); }
        catch (Exception e) { Debug.LogError("GetInstances<XRInputSubsystem> Error! " + e); }

        if (xISs.Count == 1)
        {
            Debug.Log("Found XRInputSubsystem " + xISs[0].ToString());
            return xISs[0];
        }
        else if (xISs.Count > 1)
        {
            Debug.LogError("Found more than one subsystem from XRInputSubsystem!");
        }
        else if(xISs.Count == 0)
        {
            Debug.LogError("No XRInputSubsystem found!");
        }
        return new XRInputSubsystem();
    }

    private static List<XRInputSubsystem> Get_subsys_all()
    {
        List<XRInputSubsystem> xISs = new List<XRInputSubsystem>();
        try { SubsystemManager.GetInstances<XRInputSubsystem>(xISs); }
        catch (Exception e) { Debug.LogError("GetInstances<XRInputSubsystem> Error! " + e); }
        return xISs;
    }

    public static float Get_trigger_val(InputDevice device)
    {
        float trigger = 0.0f;
        device.TryGetFeatureValue(CommonUsages.trigger, out trigger);
        return trigger;
    }

    public static float Get_grab_val(InputDevice device)
    {
        float grab_trigger = 0.0f;
        device.TryGetFeatureValue(CommonUsages.grip, out grab_trigger);
        return grab_trigger;
    }

    public static float Get_trigger(XRNode node)
    {
        float trigger = 0.0f;
        switch (node)
        {
            case XRNode.LeftHand:
                LeftControllerNode.TryGetFeatureValue(CommonUsages.trigger, out trigger);
                break;
            case XRNode.RightHand:
                RightControllerNode.TryGetFeatureValue(CommonUsages.trigger, out trigger);
                break;
        }

        return trigger;
    }

    public static bool Get_xbutton(InputDevice device)
    {
        bool xbutton = false;
        device.TryGetFeatureValue(CommonUsages.primaryButton, out xbutton);
        return xbutton;
    }

    public static bool Get_ybutton(InputDevice device)
    {
        bool ybutton = false;
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out ybutton);
        return ybutton;
    }

    public static bool Get_xbutton(XRNode node)
    {
        bool xbutton = false;
        switch (node)
        {
            case XRNode.LeftHand:
                LeftControllerNode.TryGetFeatureValue(CommonUsages.primaryButton, out xbutton);
                break;
            case XRNode.RightHand:
                RightControllerNode.TryGetFeatureValue(CommonUsages.primaryButton, out xbutton);
                break;
        }
        return xbutton;
    }

    public static bool Get_ybutton(XRNode node)
    {
        bool ybutton = false;
        switch (node)
        {
            case XRNode.LeftHand:
                LeftControllerNode.TryGetFeatureValue(CommonUsages.secondaryButton, out ybutton);
                break;
            case XRNode.RightHand:
                RightControllerNode.TryGetFeatureValue(CommonUsages.secondaryButton, out ybutton);
                break;
        }
        return ybutton;
    }

    public static InputDevice Get_device(XRNode node)
    {
        InputDevice device = new InputDevice();
        switch (node)
        {
            case XRNode.Head:
                device = HeadNode;
                break;
            case XRNode.LeftHand:
                device = LeftControllerNode;
                break;
            case XRNode.RightHand:
                device = RightControllerNode;
                break;
        }
        return device;
    }

    public static float Get_JS_horri(InputDevice device)
    {
        return Get_JS_2d(device).x;
    }

    public static float Get_JS_vert(InputDevice device)
    {
        return Get_JS_2d(device).y;
    }

    /// <summary>
    /// Horizontal then vertical, left: -1, right: 1, down: -1, up 1;
    /// </summary>
    /// <returns></returns>
    public static Vector2 Get_JS_2d(InputDevice device)
    {
        Vector2 axis2d = new Vector2();
        device.TryGetFeatureValue(CommonUsages.primary2DAxis,out axis2d);
        return axis2d;
    }

    public static void Recenter()
    {
        Subsystem.TryRecenter();
    }

    public static Vector3 Get_device_Angularspeed(XRNode node)
    {
        switch(node)
        {
            case XRNode.Head:
                return Get_head_Angularspeed();
            case XRNode.LeftHand:
                return Get_device_Angularspeed(LeftControllerNode);
            case XRNode.RightHand:
                return Get_device_Angularspeed(RightControllerNode);
        }
        return Vector3.zero;
    }

    public static Vector3 Get_head_Angularspeed()
    {
        return Get_device_Angularspeed(HeadNode);
    }

    public static Vector3 Get_device_Angularspeed(InputDevice device)
    {
        Vector3 AV = new Vector3();
        device.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out AV);
        AV *= Mathf.Rad2Deg;
        return AV;
    }

    public static Quaternion Get_device_Orientation(XRNode node)
    {
        switch (node)
        {
            case XRNode.Head:
                return Get_head_Orientation();
            case XRNode.LeftHand:
                return Get_Orientation(LeftControllerNode);
            case XRNode.RightHand:
                return Get_Orientation(RightControllerNode);
        }
        return Quaternion.identity;
    }

    public static Quaternion Get_head_Orientation()
    {
        Quaternion ori = new Quaternion();
        HeadNode.TryGetFeatureValue(CommonUsages.deviceRotation, out ori);
        return ori;
    }

    public static Quaternion Get_Orientation(InputDevice device)
    {
        Quaternion ori = new Quaternion();
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out ori);
        return ori;
    }

    public static void SetTrackingMode(TrackingOriginModeFlags origin_mode)
    {
        List<XRInputSubsystem> xISs = Get_subsys_all();
        foreach(XRInputSubsystem xIS in xISs)
        {
            xIS.TrySetTrackingOriginMode(TrackingOriginModeFlags.TrackingReference);
        }
    }
}
