using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject car;
    [SerializeField] private Transform carPos;
    [SerializeField] private Transform CarHolder;
    [SerializeField] private List<GameObject> cars = new List<GameObject>(); 
    [SerializeField] private bool isRightSide;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }
    private IEnumerator SpawnCars() 
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            GameObject gameObj=Instantiate(cars[Random.Range(0,3)], carPos.position, Quaternion.identity,CarHolder);
            Destroy(gameObj, 15);
            if (!isRightSide)
            {
                gameObj.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        
    }
}
