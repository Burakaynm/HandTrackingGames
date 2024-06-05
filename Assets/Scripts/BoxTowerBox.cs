using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTowerBox : MonoBehaviour
{
    private float min_x = -2f, max_x = 2f;
    private bool canMove;
    private float move_speed = 2f;
    private Rigidbody2D rb;

    private bool ignoreCollision;
    private bool ignoreTrigger;
    public bool isGameOver;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    void Start()
    {
        canMove = true;
        if (Random.Range(0, 2) > 0)
        {
            move_speed *= -1f;
        }
        BoxTowerGameController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_speed * Time.deltaTime;
            if (temp.x > max_x)
            {
                move_speed *= -1f;
            }
            else if (temp.x < min_x)
            {
                move_speed *= -1f;
            }
            transform.position = temp;
        }
    }
    public void DropBox()
    {
        canMove = false;
        rb.gravityScale = Random.Range(2, 4);
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision) return;
        if (target.gameObject.tag == "Ground")
        {
            ignoreCollision = true;
            BoxTowerGameController.instance.addScore();
            Invoke("OnGround", 0f);
        }
        if (target.gameObject.tag == "Box")
        {
            ignoreCollision = true;
            BoxTowerGameController.instance.addScore();
            BoxTowerGameController.instance.MoveCamera();
            Invoke("OnGround", 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger) return;
        if (target.gameObject.tag == "GameOver")
        {
            CancelInvoke("OnGround");
            isGameOver = true;
            ignoreTrigger = true;
            BoxTowerGameController.instance.SetGameOver();
            //Invoke("RestartGame", 0f);

        }
    }
    public void OnGround()
    {
        if (isGameOver) return;
        ignoreCollision = true;
        BoxTowerGameController.instance.SpawnNewBox();
    }
}
