using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    Vector3[] smoothPositions;
    public float smoothingFactor = 0.1f;
    public Transform handBase;
    void Start()
    {
        smoothPositions = new Vector3[handPoints.Length];
        for (int i = 0; i < handPoints.Length; i++)
        {
            smoothPositions[i] = handPoints[i].transform.localPosition;
        }
    }
    void HandPositioner()
    {
        if (Vector2.Distance(handPoints[5].transform.position, handPoints[4].transform.position)< Vector2.Distance(handPoints[2].transform.position, handPoints[3].transform.position))
        {
            HandController.instance.FingerMove(Finger.Thumb,FingerMove.Close);
        }
        else
        {
            HandController.instance.FingerMove(Finger.Thumb, FingerMove.Open);
        }
        if (Vector2.Distance(handPoints[5].transform.position, handPoints[8].transform.position)< Vector2.Distance(handPoints[5].transform.position, handPoints[6].transform.position))
        {
            HandController.instance.FingerMove(Finger.Index,FingerMove.Close);
        }
        else
        {
            HandController.instance.FingerMove(Finger.Index, FingerMove.Open);
        }
        if (Vector2.Distance(handPoints[9].transform.position, handPoints[12].transform.position)< Vector2.Distance(handPoints[9].transform.position, handPoints[10].transform.position))
        {
            HandController.instance.FingerMove(Finger.Middle,FingerMove.Close);
        }
        else
        {
            HandController.instance.FingerMove(Finger.Middle, FingerMove.Open);
        }
        if (Vector2.Distance(handPoints[13].transform.position, handPoints[16].transform.position)< Vector2.Distance(handPoints[13].transform.position, handPoints[14].transform.position))
        {
            HandController.instance.FingerMove(Finger.Ring,FingerMove.Close);
        }
        else
        {
            HandController.instance.FingerMove(Finger.Ring, FingerMove.Open);
        }
        if (Vector2.Distance(handPoints[17].transform.position, handPoints[20].transform.position)< Vector2.Distance(handPoints[17].transform.position, handPoints[18].transform.position))
        {
            HandController.instance.FingerMove(Finger.Little,FingerMove.Close);
        }
        else
        {
            HandController.instance.FingerMove(Finger.Little, FingerMove.Open);
        }
    }
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        for (int i = 0; i < 21; i++)
        {
            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            Vector3 targetPosition = new Vector3(x, y, z);
            //2-4,5-8,9-12,13-16,17-20
            // Lerp fonksiyonu ile yeni pozisyonu yumuþatarak hesapla
            smoothPositions[i] = Vector3.Lerp(smoothPositions[i], targetPosition, smoothingFactor);

            handPoints[i].transform.localPosition = smoothPositions[i];
        }
        handBase.position = (handPoints[9].transform.position + handPoints[13].transform.position) / 2;
        HandPositioner();
    }
}