using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.IO;

public class EndlessRunnerPlayer : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public Text scoreText;
    public static float score = 0;
    public EndlessRunnerObstacleDestroy destroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        //playerDirection = new Vector2(0, directionY).normalized;

        if (directionY > 0)
        {
            MoveUp();
        }
        // Aþaðý yön (negatif)
        else if (directionY < 0)
        {
            MoveDown();
        }
        else
            StopMove();
    }

    void MoveUp() 
    {
        transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
    }

    void StopMove()
    {
        transform.Translate(Vector2.zero);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            score += 1;
            scoreText.text = ((int)score).ToString();
        }
    }

    

}
