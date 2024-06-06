using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void Update()
    {
        HandController.IsAction();
        textMeshProUGUI.text = "Action: " + HandController.onAction + "\n" + "CanAction: " + HandController.canAction;
    }
}
