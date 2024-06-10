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
                FileWriter.SaveScoreToFile("Box Tower", score.ToString());
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



}
