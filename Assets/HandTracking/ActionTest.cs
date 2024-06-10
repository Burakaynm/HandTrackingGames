using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void Update()
    {
        if (HandController.onAction)
        {
            Debug.Log("Action");
            Debug.Log(FingersAndAction.handAction.ToString());
        }
        else
        {
            Debug.Log("NotAction");
            Debug.Log(FingersAndAction.handAction.ToString());
        }
        textMeshProUGUI.text = "Action: " + HandController.onAction + "\n" + "CanAction: " + HandController.canAction;
    }
}
