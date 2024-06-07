using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public static class HandController
{
    public static Finger[] fingers = new Finger[5];
    public static FingerWithAngle[] angles = new FingerWithAngle[4];
    public static bool canAction = true;
    public static bool onAction;
    public static bool onActionPersistent = false;

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
            angles[i] = new FingerWithAngle(fingers[i], fingers[i + 1], 10,FingersAngle.AngleUp);
        }
    }

    public static bool IsAction()
    {
        if (FingersAndAction.handAction==HandAction.Close || FingersAndAction.handAction == HandAction.Open)
        {
            bool allFingersOpen = true;
            bool allFingersClosed = true;

            for (int i = 0; i < fingers.Length; i++)
            {
                if (true)//FingersAndAction.activeFingers.Contains(fingers[i].fingerName))
                {
                    if (fingers[i].fingerState == FingerState.Open)
                    {
                        allFingersClosed = false;
                    }
                    else if (fingers[i].fingerState == FingerState.Close)
                    {
                        allFingersOpen = false;
                    }
                }
            }
            if (FingersAndAction.handAction == HandAction.Close)
            {
                if (allFingersOpen)
                {
                    canAction = true;
                }

                if (canAction && allFingersClosed)
                {
                    HandsActionEvents.InvokeActionDone();
                    onAction = true;
                    onActionPersistent = true;
                    canAction = false;
                }
                else if (!allFingersClosed)
                {
                    if (onAction)
                    {
                        HandsActionEvents.InvokeActionRelased();
                    }
                    onAction = false;
                    onActionPersistent = false;
                }

                if (onActionPersistent && allFingersClosed)
                {
                    onAction = true;
                }
            }
            else if (FingersAndAction.handAction == HandAction.Open)
            {
                if (allFingersClosed)
                {
                    canAction = true;
                }

                if (canAction && allFingersOpen)
                {
                    HandsActionEvents.InvokeActionDone();
                    onAction = true;
                    onActionPersistent = true;
                    canAction = false;
                }
                else if (!allFingersOpen)
                {
                    if (onAction)
                    {
                        HandsActionEvents.InvokeActionRelased();
                    }
                    onAction = false;
                    onActionPersistent = false;
                }

                if (onActionPersistent && allFingersOpen)
                {
                    onAction = true;
                }
            }
        }
        else if (FingersAndAction.handAction == HandAction.AngleUp || FingersAndAction.handAction == HandAction.AngleDown)
        {
            bool allFingersAngleUp = true;
            bool allFingersAngleDown = true;

            for (int i = 0; i < angles.Length; i++)
            {
                if (true)//FingersAndAction.activeFingers.Contains(angles[i].finger1.fingerName) && FingersAndAction.activeFingers.Contains(angles[i].finger2.fingerName))
                {
                    if (angles[i].fingersAngle == FingersAngle.AngleUp)
                    {
                        allFingersAngleDown = false;
                    }
                    else if (angles[i].fingersAngle == FingersAngle.AngleDown)
                    {
                        allFingersAngleUp = false;
                    }
                }

            }
            if (FingersAndAction.handAction == HandAction.AngleUp)
            {

                if (allFingersAngleDown)
                {
                    canAction = true;
                }

                if (canAction && allFingersAngleUp)
                {
                    HandsActionEvents.InvokeActionDone();
                    onAction = true;
                    onActionPersistent = true;
                    canAction = false;
                }
                else if (!allFingersAngleUp)
                {
                    if (onAction)
                    {
                        HandsActionEvents.InvokeActionRelased();
                    }
                    onAction = false;
                    onActionPersistent = false;
                }

                // Persist onAction if the condition is met
                if (onActionPersistent && allFingersAngleUp)
                {
                    onAction = true;
                }
            }
            else if (FingersAndAction.handAction == HandAction.AngleDown)
            {

                if (allFingersAngleUp)
                {
                    canAction = true;
                }

                if (canAction && allFingersAngleDown)
                {
                    HandsActionEvents.InvokeActionDone();
                    onAction = true;
                    onActionPersistent = true;
                    canAction = false;
                }
                else if (!allFingersAngleDown)
                {
                    if (onAction)
                    {
                        HandsActionEvents.InvokeActionRelased();
                    }
                    onAction = false;
                    onActionPersistent = false;
                }
                if (onActionPersistent && allFingersAngleDown)
                {
                    onAction = true;
                }
            }
        }
        return onAction;
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
public class FingerWithAngle
{
    public Finger finger1, finger2;
    public FingersAngle fingersAngle;
    public float angle;

    public FingerWithAngle(Finger finger1_, Finger finger2_, float angle_, FingersAngle fingersAngle_)
    {
        finger1 = finger1_;
        finger2 = finger2_;
        angle = angle_;
        this.fingersAngle = fingersAngle_;
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
public enum FingersAngle
{
    AngleUp,
    AngleDown
}
