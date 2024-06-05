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
    public List<FingerWithAnimator> fingersWithAnimators;


    public void SetSelectedFingers()
    {
        List<string> selectedFingerNames = new List<string>();
        selectedFingerNames.Clear();
        foreach(DropdownMultiSelect.Item item in fingerSelection.items)
        {
            if (item.isOn)
            {
                selectedFingerNames.Add(item.itemName);
            }
        }
        FingersAndAction.SetActiveFingers(selectedFingerNames);
        PlayAnimation();
    }
    public void SetAction()
    {
        FingersAndAction.SetSelectedAction(actionSelection.selectedText.text);
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        foreach (FingerWithAnimator fingerwa in fingersWithAnimators)
        {
            fingerwa.animator.Play("Empty");
        }
        for (int i=0; i < fingersWithAnimators.Count ; i++)
        {
            if (FingersAndAction.activeFingers.Contains(fingersWithAnimators[i].fingerName))
            {
                fingersWithAnimators[i].animator.Play(FingersAndAction.handAction.ToString());
            }
        }
    }
}


[Serializable]
public class FingerWithAnimator
{
    public FingerName fingerName;
    public Animator animator;
}