using System.IO;
using UnityEngine;

public static class SaveManager
{
    private static readonly string SaveDirectory = Application.persistentDataPath;

    public static void Save<T>(string fileName, T data)
    {
        string path = Path.Combine(SaveDirectory, fileName);
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);
        Debug.Log($"Saved data to {path}");
    }
    public static T Load<T>(string fileName) where T : new()
    {
        string path = Path.Combine(SaveDirectory, fileName);

        if (!File.Exists(path))
        {
            Debug.LogWarning($"No save file found at {path}. Returning new instance of {typeof(T).Name}.");
            return new T(); // 파일이 없으면 기본값 반환
        }

        string json = File.ReadAllText(path);
        T data = JsonUtility.FromJson<T>(json);

        Debug.Log($"Loaded data from {path}");
        return data;
    }

    public static void DeleteSave(string fileName)
    {
        string path = Path.Combine(SaveDirectory, fileName);

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"Deleted save file at {path}");
        }
        else
        {
            Debug.LogWarning($"No save file found at {path} to delete.");
        }
    }
}
