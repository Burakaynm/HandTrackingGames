using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndlessRunnerObstacleDestroy : MonoBehaviour
{
    private GameObject player;
    public static bool isDeath = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDeath)
            {
                Destroy(player.gameObject);
            }
            Time.timeScale = 0f;
            SaveScoreToFile((int)EndlessRunnerPlayer.score);
            isDeath = true;
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
