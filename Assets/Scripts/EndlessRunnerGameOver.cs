using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessRunnerGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (EndlessRunnerObstacleDestroy.isDeath)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
