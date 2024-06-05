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
            var animator = animators.Find(a => a.fingerName == finger)?.animator;
            if (animator != null)
            {
                switch (action)
                {
                    case HandAction.close:
                        animator.Play("Move");
                        break;
                    case HandAction.open:
                        animator.Play("Move", -1);
                        break;
                    case HandAction.angleUp:
                        animator.Play("Agnle");
                        break;
                    case HandAction.angleDown:
                        animator.Play("Agnle", -1);
                        break;
                }
            }
        }
    }
    /*
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
    */

    public void SetFingers()
    {
        fingers.Clear(); // Önce mevcut listeyi temizle

        foreach (var item in fingerSelection.items)
        {
            FingerName selectedFinger;

            // Enum.TryParse kullanarak seçili öðenin metnini enum'a çevir
            if (Enum.TryParse<FingerName>(item.itemName, out selectedFinger))
            {
                fingers.Add(selectedFinger); // Ekleme iþlemi
            }
            else
            {
                Debug.LogWarning("Invalid finger name: " + item.itemName);
            }
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