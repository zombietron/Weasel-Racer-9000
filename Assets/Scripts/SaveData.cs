using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveData
{
    
    public static void SaveGameData()
    {
        //make a string to declare the path to the save file
        string path = Application.persistentDataPath + "/save.json";

        //create a stream writer so we can control file access (open/close)

        //check the path in console just in case (debugging purposes)
        //Debug.Log(path);
        //create a new data object
        Data d = new Data();

        //grab the values we're saving from the Game Manager, in this case, the last chosen car and the High Score
        
        d.lastCarChosen = GameManager.Manager.CarChoice;
        d.highScore = GameManager.Manager.HighScore;
        
        //convert our provided save object to Json
        string saveFile = JsonUtility.ToJson(d);

        //check if the file exists if not, create the save file
        
        if(!File.Exists(path))
        {
            File.Create(path);
        }

        StreamWriter write = new StreamWriter(path);
        //write save file to disk (note this will completely overwrite the existing save file. 
        write.Write(saveFile);
        write.Close();
    }

    public static void LoadGameData()
    {

        string path = Application.persistentDataPath + "/save.json";

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
            Debug.LogWarning("No Save File Detected, Starting game with fresh file.");

        
    }
}

//Our save data class to be created when we save the game. 
public class Data 
{
    public int lastCarChosen;
    public int highScore;
}
