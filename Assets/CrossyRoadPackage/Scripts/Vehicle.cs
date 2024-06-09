using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
       Destroy(gameObject, 30f);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("girdi");
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        Destroy(collision.gameObject);
    //        Debug.Log("çarptý");
    //        //Time.timeScale = 0f;
    //    }
    //}

}
