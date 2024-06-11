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
    private string filePath = "C:\\Users\\osman\\OneDrive\\Masaüstü\\mail.txt";

    // OnApplicationQuit metodu uygulama kapanmadan hemen önce çaðrýlýr
    private void OnApplicationQuit()
    {
        // Dosya içeriðini oku
        try
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                string therapistMail = PlayerPrefs.GetString("therapistMail").Trim();
                therapistMail = therapistMail.Replace("\u200B", "");
                SimpleGmailSender.SendEmail(therapistMail, PlayerPrefs.GetString("username"), content);
                File.Delete(filePath);
                Debug.Log("Dosya baþarýyla silindi: " + filePath);
            }
            else
            {
                Debug.LogError("Dosya bulunamadý: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Dosya okunamadý: " + ex.Message);
        }
    }
}
