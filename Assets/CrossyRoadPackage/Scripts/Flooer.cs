using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Flooer : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private bool isPlayerOn;

    private void Start()
    {
        InvokeRepeating(nameof(DestroyFlooer), 15f, 0.5f);
    }
    void Update()
    {

        if (!isPlayerOn)
        {
            MoveFlooer();
        }
        else
        {
            StopFlooer();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("girdi");
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Flooer"))
        {
            //Destroy(collision.gameObject);
            isPlayerOn = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Flooer"))
        {
            //Destroy(collision.gameObject);
            isPlayerOn = false;

        }
    }
    private void MoveFlooer()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //Destroy(gameObject, 30f);
    }
    private void StopFlooer()
    {
        transform.Translate(Vector3.zero);
        //Destroy(gameObject, 30f);
    }
    private void DestroyFlooer()
    {
        if (Player.instance.gameObject.transform.position.x != transform.position.x)
        {
            Destroy(gameObject);
        }
            
    }
}
