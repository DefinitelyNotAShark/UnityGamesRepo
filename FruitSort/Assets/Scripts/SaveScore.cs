using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveScore
{
    public static List<GameData> savedGames = new List<GameData>();

    public static void Save()
    {
        //can be called anywhere
        savedGames.Add(GameData.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, SaveScore.savedGames);
        file.Close();
    }

    public static void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            SaveScore.savedGames = (List<GameData>)bf.Deserialize(file);
            file.Close();
        }
    }
}

