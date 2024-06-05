using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdZemin : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if (FlappyBirdGameManager.Instance.isGameStarted)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x < -0.4)
            {
                transform.position = new Vector3(0.5f, transform.position.y, 0);
            }
        }
    }
}