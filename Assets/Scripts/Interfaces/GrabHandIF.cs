using UnityEngine;

public interface GrabHandIF
{
    void Grab();
    void Grab(Transform other_TRANS);
    void UnGrab();
    void ChangeGrabingState(bool _is_grabing);
    void ChangeAbleGrabState(bool _able_to_grab);

}
