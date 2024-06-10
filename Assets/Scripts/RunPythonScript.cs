using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class RunPythonScript : MonoBehaviour
{
    private bool isPythonScriptRunning = false;
    private bool isGameStarted = false;
    private Process pythonProcess;

    void Start()
    {
        StartPythonScript();
    }

    void Update()
    {
        if (isPythonScriptRunning && !isGameStarted)
        {
            // Python script tamamland�ysa oyunu ba�lat
            if (!Process.GetProcessesByName("unity_el_izleme").Any())
            {
                isPythonScriptRunning = false;
                StartGame();
            }
        }
    }

    void StartPythonScript()
    {
        string pythonExePath = System.IO.Path.Combine(Application.streamingAssetsPath, "unity_el_izleme.exe");

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = pythonExePath;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;

        pythonProcess = new Process(); // Process nesnesini de�i�kene atay�n
        pythonProcess.StartInfo = startInfo;
        pythonProcess.Start();

        isPythonScriptRunning = true;
    }

    void StartGame()
    {
        // Oyun ba�lang�� mant���n� buraya ekle
        isGameStarted = true;
        UnityEngine.Debug.Log("Game Started");
    }

    void OnApplicationQuit()
    {
        // Unity uygulamas� kapand���nda Python process'ini kapat�n
        if (pythonProcess != null && !pythonProcess.HasExited)
        {
            pythonProcess.Kill();
        }
    }
}
