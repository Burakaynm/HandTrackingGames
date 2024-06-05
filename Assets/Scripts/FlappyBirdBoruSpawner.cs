using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdBoruSpawner : MonoBehaviour
{
    public GameObject boru;
    public GameObject boruSpawnPos;
    public float boruSpawnSuresi;

    private void Start()
    {
        InvokeRepeating("BoruSpawn", 1f, boruSpawnSuresi);
    }

    void BoruSpawn()
    {
        if (FlappyBirdGameManager.Instance.isGameStarted)
        {
            GameObject boruTemp = Instantiate(boru);
            boruTemp.transform.position = new Vector3(boruSpawnPos.transform.position.x, Random.Range(-5f, -2f));
        }
    }
}
