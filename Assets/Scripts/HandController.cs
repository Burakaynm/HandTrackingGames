using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    // Singleton instance of HandController
    public static HandController instance;

    // List of fingers with their root objects
    [SerializeField] public List<FingerWithRoot> fingers;

    private void Start()
    {
        instance = this;
    }

    // Method to control the movement of a finger
    public void FingerMove(Finger finger, FingerMove move)
    {
        foreach (FingerWithRoot fingerWithRoot in fingers)
        {
            if (fingerWithRoot.finger == finger)
            {
                // Get the Animator component from the finger root
                Animator animator = fingerWithRoot.fingerRoot.GetComponent<Animator>();

                // Determine the animation direction based on the movement
                float direction = move == global::FingerMove.Open ? -1 : 1;

                // Play the animation
                animator.Play("Move", 0, direction);
            }
        }
    }
}

[System.Serializable]// Class representing a finger and its root object
public class FingerWithRoot
{
    public GameObject fingerRoot;
    public Finger finger;
}

// Enum to represent different fingers
public enum Finger
{
    Thumb,
    Index,
    Middle,
    Ring,
    Little
}

// Enum to represent finger movements
public enum FingerMove
{
    Open,
    Close
}
