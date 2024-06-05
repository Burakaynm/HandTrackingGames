using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdBoruHareketi : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(this.gameObject, 10);
    }
    private void Update()
    {
        if (FlappyBirdGameManager.Instance.isGameStarted)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
