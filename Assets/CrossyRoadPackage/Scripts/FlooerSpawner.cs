using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlooerSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject car;
    [SerializeField] private Transform flooerPos;
    //[SerializeField] private Transform flooerHolder;
    [SerializeField] private List<GameObject> flooer = new List<GameObject>();
    
    void Start()
    {
        StartCoroutine(SpawnCars());

    }
    private IEnumerator SpawnCars()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(2, 5));
            GameObject gameObj = Instantiate(flooer[0], flooerPos.position, Quaternion.identity);
            //Debug.Log("playerýn xi:" + Player.instance.gameObject.transform.position.x);
            //Debug.Log("water xi:" + transform.position.x);
            //if (Player.instance.gameObject.transform.position.x != transform.position.x)
            //{
            //    Destroy(gameObj, 15);
            //}

        }

    }
}
