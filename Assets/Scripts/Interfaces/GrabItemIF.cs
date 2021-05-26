
public interface GrabItemIF
{
    void BeGrab();
    void BeRelease();
    void GrabableHighlight();
    void ChangeGrabableState(bool _grabable);
    void ChangeBeingGrabedState(bool _being_grabed);
}
