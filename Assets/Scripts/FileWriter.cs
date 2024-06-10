using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class FileWriter
{

    public static void SaveScoreToFile(string gameName,string score)
    {
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
        File.AppendAllText(path, "Game: Crossy Road, " + "Score: " + score + ", Action: " + FingersAndAction.handAction.ToString() + ", Fingers: " + fingers + "\n");
    }
}
