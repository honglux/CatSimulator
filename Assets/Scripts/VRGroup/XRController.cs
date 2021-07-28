using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRController : MonoBehaviour
{
    public static XRController IS;

    private void Awake()
    {
        IS = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init_XR();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init_XR()
    {
        XRDeviceManager.InitXRDevice();
        XRDeviceManager.SetTrackingMode(UnityEngine.XR.TrackingOriginModeFlags.Floor);
    }

    public void RecenterVRPosition()
    {
        TSRC.TSIS.Body_TRANS.position = new Vector3(
            -TSRC.TSIS.Camera_TRANS.position.x,
            TSRC.TSIS.Body_TRANS.position.y,
            -TSRC.TSIS.Camera_TRANS.position.z);

    }
}
