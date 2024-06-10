using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;
using System;

public class BoxTowerGameController : MonoBehaviour
{
    public static BoxTowerGameController instance;
    public BoxTowerBoxSpawn boxSpawner;
    public BoxTowerBox currentBox;
    public BoxTowerCameraFollow cameraFollow;
    public int score;
    public Text scoretxt;
    public int moveCount;
    public GameObject gameOverPanel;
    private bool gameOver = false;
    private bool isWrited;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1f;
        score = 0;
        isWrited = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            if (!isWrited)
            {
                SaveScoreToFile(score);
                isWrited = true;   
            }
        }
    }
    private void OnEnable()
    {
        HandsActionEvents.ActionDone += GetMouseInput;
    }
    private void OnDisable()
    {
        HandsActionEvents.ActionDone -= GetMouseInput;
    }
    void GetMouseInput(bool tempBool)
    {
            currentBox.DropBox();
    }
    public void SetGameOver()
    {
        gameOver = true;
    }
    public void SpawnNewBox()
    {
        Invoke("NextBox", 0f);
    }
    public void NextBox()
    {
        boxSpawner.SpawnBox();
    }
    public void addScore()
    {
        score++;
        scoretxt.text = "" + score;
    }
    public void MoveCamera()
    {
        moveCount++;
        if (moveCount == 2)
        {
            moveCount = 0;
            cameraFollow.targetPos.y += 2f;
        }
    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //private void SaveScoreToFile(int score)
    //{
    //    string path = "C://Users//serha//Desktop/score.txt";

    //    if (!File.Exists(path))
    //    {
    //        File.WriteAllText(path, "Game Scores\n");
    //    }
    //    File.AppendAllText(path, "Game: Box Tower, " + "Score: " + score.ToString() + "\n");
    //}

    public void SaveScoreToFile(int score)
    {
        //string path = "C:\\Users\\osman\\OneDrive\\Masa�st�\\mail.txt";
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "mail.txt");

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Game Scores\n");
        }
        string fingers = "";
        for (int i = 0; i < FingersAndAction.activeFingers.Count; i++)
        {
            fingers += FingersAndAction.activeFingers[i].ToString() + ", ";
        }
        File.AppendAllText(path, "Game: Tower Box, " + "Score: " + score.ToString() + ", Action: " + FingersAndAction.handAction.ToString() + ", Fingers: " + fingers + "\n");
    }

}
