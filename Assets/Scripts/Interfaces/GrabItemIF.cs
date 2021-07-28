
public interface GrabItemIF
{
    bool IsGrabable();
    void BeGrab();
    void BeRelease();
    void Selected();
    void Deselected();
    void GrabableHighlight();
    void GrabableDehighlight();
    void ChangeGrabableState(bool _grabable);
    void ChangeBeingGrabedState(bool _being_grabed);
}
