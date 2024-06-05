using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunnerObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float minY; 
    public float maxY;
    public float waitForSpawn;
    private float spawnTime;

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + waitForSpawn;
            
        }
        //Destroy(obstacle, 10f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (!EndlessRunnerObstacleDestroy.isDeath) 
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        
    }
}
