using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Bird : MonoBehaviour
{
    public int ziplamaGucu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverBestScoreText;
    public GameObject gameOverPanel;


    Rigidbody2D rb;
    int score = 0;
    bool isDeath;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDeath = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = score.ToString();
        scoreText.gameObject.SetActive(false);
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);

        }
        gameOverBestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        SaveScoreToFile(score);
    }

    private void Update()
    {
        if (FlappyBirdGameManager.Instance.isGameStarted)
        {
            rb.gravityScale = 1f;
            if (Input.GetMouseButtonDown(0) && isDeath == false)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * ziplamaGucu);
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            transform.DORotate(new Vector3(0, 0, -20), 0.5f);
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, 20), 0.5f);
        }
    }

    private void SaveScoreToFile(int score)
    {
        string path = "C://Users//serha//Desktop/score.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Game Scores\n");
        }

        File.AppendAllText(path, "Score: " + score.ToString() + "\n");
    }
}
