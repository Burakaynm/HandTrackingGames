using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public static class HandController
{
    public static Finger[] fingers = new Finger[5];

    static HandController()
    {
        InitializeFingers();
    }

    private static void InitializeFingers()
    {
        for (int i = 0; i < fingers.Length; i++)
        {
            fingers[i] = new Finger((FingerName)i, FingerState.Open);
        }
    }
}

[System.Serializable]
public class Finger
{
    public FingerName fingerName;
    public FingerState fingerState;

    public Finger(FingerName name, FingerState state)
    {
        fingerName = name;
        fingerState = state;
    }
}

public enum FingerName
{
    Thumb,    // Baþ Parmak
    Index,    // Ýþaret Parmak
    Middle,   // Orta Parmak
    Ring,     // Yüzük Parmak
    Little    // Serçe Parmak
}


public enum FingerState
{
    Open,
    Close
}
