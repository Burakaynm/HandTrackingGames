using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public static class HandController
{
    public static Finger[] fingers = new Finger[5];
    public static Angle[] angles = new Angle[4];

    static HandController()
    {
        InitializeFingers();
        InitializeAngles();
    }

    private static void InitializeFingers()
    {
        for (int i = 0; i < fingers.Length; i++)
        {
            fingers[i] = new Finger((FingerName)i, FingerState.Open);
        }
    }
    private static void InitializeAngles()
    {
        for (int i = 0; i < angles.Length; i++)
        {
            angles[i] = new Angle(fingers[i], fingers[i+1],10);
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
[System.Serializable]
public class Angle
{
    public Finger finger1, finger2;
    public float angle;

    public Angle(Finger finger1_, Finger finger2_, float angle_)
    {
        finger1 = finger1_;
        finger2 = finger2_;
        angle = angle_;
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
