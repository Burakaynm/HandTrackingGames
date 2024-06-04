using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public GameObject errorPanel;
    Vector3[] smoothPositions;
    public float smoothingFactor = 0.1f;
    public TextMeshProUGUI avarageFingerDistanceText_UI,distanceFromCamText_UI,fingerStateText_UI,errorText_UI;
    bool handOutRange, handOutDistance;
    public float dataTimeout = 2.0f;
    private float lastReceivedTime;

    void Start()
    {
        lastReceivedTime = Time.time;
        smoothPositions = new Vector3[handPoints.Length];
        for (int i = 0; i < handPoints.Length; i++)
        {
            smoothPositions[i] = handPoints[i].transform.localPosition;
        }
    }


    void Update()
    {
        string data = udpReceive.data;

        if (!string.IsNullOrEmpty(data))
        {
            lastReceivedTime = Time.time;
            data = data.Trim(new char[] { '[', ']' });
            string[] points = data.Split(',');

            if (points.Length == 63)
            {
                for (int i = 0; i < 21; i++)
                {
                    float x = 7 - float.Parse(points[i * 3]) / 100;
                    float y = float.Parse(points[i * 3 + 1]) / 100;
                    float z = float.Parse(points[i * 3 + 2]) / 100;

                    Vector3 targetPosition = new Vector3(x, y, z);
                    smoothPositions[i] = Vector3.Lerp(smoothPositions[i], targetPosition, smoothingFactor);

                    handPoints[i].transform.localPosition = smoothPositions[i];
                }

                HandPositioner();
                return;
            }
        }

        if (Time.time - lastReceivedTime > dataTimeout)
        {
            ShowErrorPanel("HAND NOT DETECTED");
            handPoints[0].transform.position = Vector3.one * 1000;
        }
    }

    void ShowErrorPanel(string errorMessage)
    {
        errorText_UI.text = errorMessage;
        if (errorPanel.transform.localScale == Vector3.zero)
        {
            errorPanel.transform.DOScale(Vector3.one, 0.5f);
        }
    }

    void HideErrorPanel()
    {
        if (errorPanel.transform.localScale != Vector3.zero)
        {
            errorPanel.transform.DOScale(Vector3.zero, 0.5f);
        }
    }

    void HandPositioner()
    {
        bool hasError = CheckPointsInRange() || CheckHandDistance();
        if (!hasError)
        {
            HideErrorPanel();
        }
        if (Vector3.Distance(handPoints[3].transform.position, handPoints[4].transform.position)*3> Vector3.Distance(handPoints[4].transform.position, handPoints[9].transform.position))
        {
            HandController.fingers[0].fingerState = FingerState.Close;
        }
        else
        {
            HandController.fingers[0].fingerState = FingerState.Open;
        }
        if (handPoints[8].transform.position.y < handPoints[6].transform.position.y)
        {
            HandController.fingers[1].fingerState = FingerState.Close;
        }
        else
        {
            HandController.fingers[1].fingerState = FingerState.Open;
        }
        if (handPoints[12].transform.position.y < handPoints[10].transform.position.y)
        {
            HandController.fingers[2].fingerState = FingerState.Close;
        }
        else
        {
            HandController.fingers[2].fingerState = FingerState.Open;
        }
        if (handPoints[16].transform.position.y < handPoints[14].transform.position.y)
        {
            HandController.fingers[3].fingerState = FingerState.Close;
        }
        else
        {
            HandController.fingers[3].fingerState = FingerState.Open;
        }
        if (handPoints[20].transform.position.y < handPoints[18].transform.position.y)
        {
            HandController.fingers[4].fingerState = FingerState.Close;
        }
        else
        {
            HandController.fingers[4].fingerState = FingerState.Open;
        }
        fingerStateText_UI.text = "";
        for (int i = 0; i < HandController.fingers.Length; i++)
        {
            fingerStateText_UI.text += HandController.fingers[i].fingerName.ToString() + " : " + HandController.fingers[i].fingerState.ToString()+"\n";
        }
        float thumbDistance = Vector3.Distance(handPoints[4].transform.position, handPoints[2].transform.position);
        float indexDistance = Vector3.Distance(handPoints[8].transform.position, handPoints[5].transform.position);
        float middleDistance = Vector3.Distance(handPoints[12].transform.position, handPoints[9].transform.position);
        float ringDistance = Vector3.Distance(handPoints[16].transform.position, handPoints[13].transform.position);
        float littleDistance = Vector3.Distance(handPoints[20].transform.position, handPoints[17].transform.position);

        float averageDistance = (thumbDistance + indexDistance + middleDistance + ringDistance + littleDistance) / 5;

        float palmToThumbAngle = Vector3.Angle(handPoints[0].transform.position - handPoints[9].transform.position, handPoints[4].transform.position - handPoints[9].transform.position);
        float palmToIndexAngle = Vector3.Angle(handPoints[0].transform.position - handPoints[9].transform.position, handPoints[8].transform.position - handPoints[9].transform.position);
        float palmToMiddleAngle = Vector3.Angle(handPoints[0].transform.position - handPoints[9].transform.position, handPoints[12].transform.position - handPoints[9].transform.position);
        float palmToRingAngle = Vector3.Angle(handPoints[0].transform.position - handPoints[9].transform.position, handPoints[16].transform.position - handPoints[9].transform.position);
        float palmToLittleAngle = Vector3.Angle(handPoints[0].transform.position - handPoints[9].transform.position, handPoints[20].transform.position - handPoints[9].transform.position);

        bool isFist = thumbDistance < 0.04f && indexDistance < 0.04f && middleDistance < 0.04f && ringDistance < 0.04f && littleDistance < 0.04f;

        Debug.Log("Is Fist: " + isFist);
        avarageFingerDistanceText_UI.text = "Average Finger Distance: " + averageDistance;
        distanceFromCamText_UI.text = "Hand-Webcam Distance: " + Vector3.Distance(handPoints[0].transform.position, handPoints[17].transform.position).ToString();
        Debug.Log("Palm to Thumb Angle: " + palmToThumbAngle);
        Debug.Log("Palm to Index Angle: " + palmToIndexAngle);
        Debug.Log("Palm to Middle Angle: " + palmToMiddleAngle);
        Debug.Log("Palm to Ring Angle: " + palmToRingAngle);
        Debug.Log("Palm to Little Angle: " + palmToLittleAngle);
    }

    bool CheckPointsInRange()
    {
        if (!handOutDistance)
        {
            handOutRange = false;
            foreach (var point in handPoints)
            {
                Vector2 pointPos = point.transform.localPosition;
                if (pointPos.y > 9 || pointPos.y < 0.5f || pointPos.x > 6.5f || pointPos.x < -5.5f)
                {
                    handOutRange = true;
                    ShowErrorPanel("HAND OUT");
                    Debug.Log("PointOut");
                    return true;
                }
            }
        }
        return false;
    }

    bool CheckHandDistance()
    {
        if (!handOutRange)
        {
            if (Vector3.Distance(handPoints[0].transform.position, handPoints[17].transform.position) < 1f)
            {
                ShowErrorPanel("HAND SO FAR");
                handOutDistance = true;
                return true;
            }
            else if (Vector3.Distance(handPoints[0].transform.position, handPoints[17].transform.position) > 3)
            {
                ShowErrorPanel("HAND SO CLOSE");
                handOutDistance = true;
                return true;
            }
            else
            {
                handOutDistance = false;
            }
        }
        return false;
    }

}
