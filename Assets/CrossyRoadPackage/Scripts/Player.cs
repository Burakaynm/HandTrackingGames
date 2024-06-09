using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Player : MonoBehaviour
{
    public static Player instance;
    public TerrainGenerator terrainGenerator;
    public int score = 0;
    public Text scoreText;
    public bool isDeath;
    private bool canTakeInput;
    public GameObject restartPanel;
    public Text lastScore;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        
        StartCoroutine(WaitForPlayerInput());
        scoreText.text = score.ToString();

    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (canTakeInput)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                transform.position += Vector3.right;
                terrainGenerator.SpawnTerrains(false, transform.position, false);
                score++;
                scoreText.text = score.ToString();

            }
        }
    }
    public void deathPlayer()
    {
        restartPanel.SetActive(true);
        string scoreTextLast = "Score: " + score.ToString();
        lastScore.text = scoreTextLast;
    }
    public void SaveScoreToFile()
    {
        string path = "C://Users//serha//Desktop/score.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Game Scores\n");
        }

        File.AppendAllText(path, "Game: Crossy Road, " + "Score: " + score.ToString() + "\n");
    }
    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(3);
        canTakeInput = true;
    }
}
