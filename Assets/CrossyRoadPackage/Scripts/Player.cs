using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using DG.Tweening;
using System;

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
    [SerializeField] Animator rabbitAnimator;

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
    private void OnEnable()
    {
        HandsActionEvents.ActionDone += Movement;
    }
    private void OnDisable()
    {
        HandsActionEvents.ActionDone -= Movement;
    }
    void Movement(bool tempBool)
    {
        if (canTakeInput)
        {
                transform.DOComplete();
                rabbitAnimator.Play("Rabbit_Run");
                transform.DOMoveX(transform.position.x+Vector3.right.x,0.665f/2).OnComplete(()=>rabbitAnimator.Play("Rabbit_Idle"));
                //transform.position += Vector3.right;
                terrainGenerator.SpawnTerrains(false, transform.position, false);
                score++;
                scoreText.text = score.ToString();
        }
    }
    public void deathPlayer()
    {
        restartPanel.SetActive(true);
        Debug.Log("öldü");
        string scoreTextLast = "Score: " + score.ToString();
        lastScore.text = scoreTextLast;
    }
    public void SaveScoreToFile()
    {
        //string path = "C:\\Users\\osman\\OneDrive\\Masaüstü\\mail.txt";
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
        File.AppendAllText(path, "Game: Crossy Road, " + "Score: " + score.ToString()+ ", Action: "+FingersAndAction.handAction.ToString() +  ", Fingers: "+fingers + "\n");
    }
    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(3);
        canTakeInput = true;
    }
}
