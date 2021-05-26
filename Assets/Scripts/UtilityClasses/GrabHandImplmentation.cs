using UnityEngine;

public static class GrabHandImplmentation
{

    /// <summary>
    /// Act the grab action; Implement with fixedjoints;
    /// </summary>
    public static void Grab_with_joint(FixedJoint joint, Rigidbody item_RB)
    {
        joint.connectedBody = item_RB;
    }

    /// <summary>
    /// Act the grab action; Implement with transform;
    /// </summary>
    public static void Grab_with_joint(Transform hand_TRANS, Transform item_TRANS)
    {
        item_TRANS.SetParent(hand_TRANS);
    }

    /// <summary>
    /// Ungrab the item; With fixed joint;
    /// </summary>
    public static void UnGrab_joint(FixedJoint joint)
    {
        joint.connectedBody = null;
    }

    /// <summary>
    /// Ungrab with the transform;
    /// </summary>
    public static void UnGrab_transform(Transform item_TRANS)
    {
        item_TRANS.SetParent(null);
    }
}
