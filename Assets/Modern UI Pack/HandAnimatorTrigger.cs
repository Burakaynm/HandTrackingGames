using Michsky.MUIP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandAnimationTrigger : MonoBehaviour
{
    public HandAction action;
    public DropdownMultiSelect fingerSelection;
    public CustomDropdown actionSelection;

    public List<FingerName> fingers;
    public List<FingerWithAnimator> animators;

    public void doAction()
    {
        foreach (FingerName finger in fingers)
        {

        }
    }

    public void SetActions()
    {
        switch (actionSelection.selectedItemIndex)
        {
            case 0:
                action = HandAction.close; break;

            case 1:
                action = HandAction.open; break;

            case 2:
                action = HandAction.angleUp; break;

            case 3:
                action = HandAction.angleDown; break;
        }
    }

    public void SetFingers()
    {
        for (int i = 0; i < fingerSelection.items.Count; i++)
        {
            
        }
    }
}

public enum HandAction
{
    close,
    open,
    angleUp,
    angleDown
}

[Serializable]
public class FingerWithAnimator
{
    public FingerName fingerName;
    public Animator animator;
}