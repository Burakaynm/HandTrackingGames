using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StaticSaveLoadManager
{
    private static string saveFilePath = Application.persistentDataPath + "/savefile.json";
    private static Dictionary<string, string> data = new Dictionary<string, string>();

    static StaticSaveLoadManager()
    {
        LoadDataFromFile();
    }

    public static void SetInt(string key, int value)
    {
        data[key] = value.ToString();
        SaveDataToFile();
    }

    public static int GetInt(string key, int defaultValue = 0)
    {
        if (data.TryGetValue(key, out string value))
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
        }
        return defaultValue;
    }

    public static void SetFloat(string key, float value)
    {
        data[key] = value.ToString();
        SaveDataToFile();
    }

    public static float GetFloat(string key, float defaultValue = 0.0f)
    {
        if (data.TryGetValue(key, out string value))
        {
            if (float.TryParse(value, out float result))
            {
                return result;
            }
        }
        return defaultValue;
    }

    public static void SetString(string key, string value)
    {
        data[key] = value;
        SaveDataToFile();
    }

    public static string GetString(string key, string defaultValue = "")
    {
        if (data.TryGetValue(key, out string value))
        {
            return value;
        }
        return defaultValue;
    }

    public static bool HasKey(string key)
    {
        return data.ContainsKey(key);
    }

    public static void DeleteKey(string key)
    {
        if (data.Remove(key))
        {
            SaveDataToFile();
        }
    }

    public static void DeleteAll()
    {
        data.Clear();
        SaveDataToFile();
    }

    private static void SaveDataToFile()
    {
        string json = JsonUtility.ToJson(new Serialization<string, string>(data));
        File.WriteAllText(saveFilePath, json);
    }

    private static void LoadDataFromFile()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            data = JsonUtility.FromJson<Serialization<string, string>>(json).ToDictionary();
        }
    }
}

[System.Serializable]
public class Serialization<K, V>
{
    public List<K> keys;
    public List<V> values;

    public Serialization(Dictionary<K, V> dictionary)
    {
        keys = new List<K>(dictionary.Keys);
        values = new List<V>(dictionary.Values);
    }

    public Dictionary<K, V> ToDictionary()
    {
        Dictionary<K, V> result = new Dictionary<K, V>();
        for (int i = 0; i < keys.Count; i++)
        {
            result[keys[i]] = values[i];
        }
        return result;
    }
}
