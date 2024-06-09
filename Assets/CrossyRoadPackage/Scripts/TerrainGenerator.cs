using UnityEngine;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private GameObject player;

    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            if (i == 0)
            {
                SpawnTerrains(true, currentPosition,true);
            }
            else
                SpawnTerrains(true, currentPosition,false);

        }
        maxTerrainCount = currentTerrains.Count;
    }

    public void SpawnTerrains(bool isStart, Vector3 playerPos, bool firstOne)
    {
        if (currentPosition.x - playerPos.x < minDistanceFromPlayer || isStart)
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                if (firstOne)
                {
                    whichTerrain = 0;
                    GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
                    currentTerrains.Add(terrain);
                    //Debug.Log("firstOne=" + (terrainDatas.Count - 1));
                }
                
                if (!firstOne)
                {
                    GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
                    currentTerrains.Add(terrain);
                    //Debug.Log("!firstOne=" + (terrainDatas.Count));
                    if (!isStart)
                    {
                        if (currentTerrains.Count > maxTerrainCount)
                        {
                            Destroy(currentTerrains[0]);
                            currentTerrains.RemoveAt(0);
                        }
                    }
                    currentPosition.x++;
                }
                
            }
        }
    }
}
