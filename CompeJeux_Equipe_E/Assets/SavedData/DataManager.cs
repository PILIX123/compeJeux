using System.IO;
using UnityEngine;

public static class DataManager
{
    public static string directory = "/SavedData/";
    public static string filename = "SavedData.json";

    public static void Save(SaveObjects so)
    {
        string dir = Application.persistentDataPath + directory;
        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        string json = JsonUtility.ToJson(dir);
        File.WriteAllText(dir + filename, json);
    }

    public static SaveObjects Load()
    {
        string fullpath = Application.persistentDataPath + directory + filename;
        SaveObjects so = new SaveObjects();

        if(File.Exists(fullpath))
        {
            string json = File.ReadAllText(fullpath);
            so = JsonUtility.FromJson<SaveObjects>(json);
        }
        else
        {
            Debug.Log("Save file doesn't exist");
        }

        return so;
    }
}
