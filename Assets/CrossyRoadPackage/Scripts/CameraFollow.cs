using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject player;    
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = player.transform.position + offset;
        }
        
    }
}
