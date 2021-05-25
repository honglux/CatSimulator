using System;

/// <summary>
/// Utilites class, used to store useful functions;
/// </summary>
public static class Utilities
{
    /// <summary>
    /// Calculate the index of the state; From index of the value_warper list to state index;
    /// </summary>
    /// <returns></returns>
    public static int State_index_cal<T>(T[] enumlist, int val_index) where T : System.Enum
    {
        return Convert.ToInt32(enumlist[val_index]);
    }
}
