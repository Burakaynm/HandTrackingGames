using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdGameManager : MonoBehaviour
{
    public static FlappyBirdGameManager Instance;
    public bool isGameStarted = false;

    private void Start()
    {
        Time.timeScale = 1f;
        Instance = this;
    }
    private void OnEnable()
    {
        HandsActionEvents.ActionDone += StartGame;
    }
    private void OnDisable()
    {
        HandsActionEvents.ActionDone -= StartGame;
    }
    void StartGame(bool temp)
    {
        if (!isGameStarted)
        {
            isGameStarted = true;
        }

    }


}
