
/// <summary>
/// Base class to wrap the values in cat or other object;
/// </summary>
[System.Serializable]
public class ValueWraperBase
{
    public string Name;
    public float Init_val;
    public float[] State_vals;  //Minimum, state1, state2..., Maxum;
    public int State_index;

    public ValueWraperBase()
    {
        Name = "";
        Init_val = 0.0f;
        State_vals = new float[0];
        State_index = 0;
    }

    /// <summary>
    /// Copy constructor;
    /// </summary>
    /// <param name="ov">Other</param>
    public ValueWraperBase(ValueWraperBase ov)
    {
        Name = ov.Name;
        Init_val = ov.Init_val;
        State_vals = ov.State_vals;
        State_index = ov.State_index;
    }

    /// <summary>
    /// Calculate the state index;
    /// </summary>
    /// <returns></returns>
    public int State_index_cal(float val)
    {
        State_index = -1;
        if (val > State_vals[State_vals.Length - 1] || val < State_vals[0])
        { return State_index; }
        for (int i = State_vals.Length - 1; i >= 0; --i) 
        {
            if (val >= State_vals[i])
            {
                if (i == State_vals.Length - 1) { State_index = i - 1; }
                else { State_index = i; }
                return State_index;
            }
        }
        return State_index;
    }
}
