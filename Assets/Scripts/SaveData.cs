using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveData
{
    public static void SaveGameData()
    {
        //string that contains our file path
        string path = Application.persistentDataPath + "/savedata.json";

        //create our save data
        Data d = new Data();

        d.lastCarChosen = GameManager.Manager.CarChoice;
        d.highScore = GameManager.Manager.HighScore;

        string saveFile = JsonUtility.ToJson(d);

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        StreamWriter writer = new StreamWriter(path);
        writer.Write(saveFile);
        writer.Close();
        
    }

    public static void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            StreamReader r = new StreamReader(path);
            string file = r.ReadToEnd();
            Data d = JsonUtility.FromJson<Data>(file);
            GameManager.Manager.HighScore = d.highScore;
            GameManager.Manager.CarChoice = d.lastCarChosen;
            r.Close();
        }
        else
            Debug.Log("No save data exists, you are starting at 0");
    }
}

public class Data
{
    public int lastCarChosen;
    public int highScore;
}
