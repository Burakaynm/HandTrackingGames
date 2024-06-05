using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTowerCameraFollow : MonoBehaviour
{
    public Vector3 targetPos;
    private float smooth = 1f;
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}
