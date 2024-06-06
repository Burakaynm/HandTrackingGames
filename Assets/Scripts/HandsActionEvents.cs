using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HandsActionEvents
{
    public static event Action<bool> ActionDone;
    public static event Action<bool> ActionRelased;
    public static void InvokeActionDone()
    {
        ActionDone?.Invoke(true);
    }
    public static void InvokeActionRelased()
    {
        ActionRelased?.Invoke(true);
    }
}
