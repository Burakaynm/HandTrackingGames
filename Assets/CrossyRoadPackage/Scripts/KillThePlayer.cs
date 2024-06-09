using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThePlayer : MonoBehaviour
{
    private Player player;
    

    private void Start()
    {
        // Player bileþenini mevcut GameObject'e ekleyin
        player = Player.instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            player.SaveScoreToFile();
            player.deathPlayer();
            Time.timeScale = 0;
            
        }
    }
}
