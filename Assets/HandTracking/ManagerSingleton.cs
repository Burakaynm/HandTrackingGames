using System;
using System.IO;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{
    private static ManagerSingleton instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    } 
    // Dosya yolunu belirtin
    private string filePath = "C:\\Users\\osman\\OneDrive\\Masa�st�\\mail.txt";

    // OnApplicationQuit metodu uygulama kapanmadan hemen �nce �a�r�l�r
    private void OnApplicationQuit()
    {
        // Dosya i�eri�ini oku
        try
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                string therapistMail = PlayerPrefs.GetString("therapistMail").Trim();
                therapistMail = therapistMail.Replace("\u200B", "");
                SimpleGmailSender.SendEmail(therapistMail, PlayerPrefs.GetString("username"), content);
                File.Delete(filePath);
                Debug.Log("Dosya ba�ar�yla silindi: " + filePath);
            }
            else
            {
                Debug.LogError("Dosya bulunamad�: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Dosya okunamad�: " + ex.Message);
        }
    }
}
