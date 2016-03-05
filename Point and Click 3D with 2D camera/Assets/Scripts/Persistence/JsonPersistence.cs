using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class JsonPersistence {

    private static string filePath = Application.persistentDataPath + "/gameData.json";

    public static bool saveFileExists() {
        return File.Exists(filePath);
    }

    public static void Save<T>(T data) where T : class {
        //string filePath = Application.persistentDataPath + "/playerInfo.json";
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate)) {
            using (StreamWriter writer = new StreamWriter(fs)) {
                JsonData jsonData = JsonMapper.ToJson(data);
                writer.Write(jsonData.ToString());
                writer.Close();
                writer.Dispose();
            }
            fs.Close();
            fs.Dispose();
        }
    }

    /**
    * Read the PersistenceData from the Json file
    */
    public static PersistenceData ReadPersistenceData() {
        //string filePath = Application.persistentDataPath + "/playerInfo.json";
        if (File.Exists(filePath)) {
            try {
                using (Stream stream = File.OpenRead(filePath)) {
                    String jsonString = File.ReadAllText(filePath);
                    JsonData jsonData = JsonMapper.ToObject(jsonString);                    
                    PersistenceData data = GetPersitenceData(jsonData);
                    return data;
                }
            } catch (Exception e) {
                Debug.Log(e.Message);
            }
        }
        return null;
    }

    /**
    * Get the PersistenceData from the Json file
    */
    private static PersistenceData GetPersitenceData(JsonData jsonData) {
        PersistenceData data = new PersistenceData();
        GameData gameData = GetGameDataFromJsonData(jsonData); 
        List<Item> itens = GetItemFromJsonData(jsonData);
        data.itens = new List<Item>();
        data.itens.AddRange(itens);
        data.gameData = gameData;

        return data;
    }

    /**
    * Retrieve the data from a JsonData and create a GameData with the info
    */
    private static GameData GetGameDataFromJsonData(JsonData jsonData) {
        PersistenceType type = PersistenceType.gameData;
        GameData gd = null;
        if (jsonData[type.ToString()].Count == 1) {
            gd = new GameData();
            gd.currentLevel = Convert.ToInt32(jsonData[type.ToString()]["currentLevel"].ToString());
                                 
        }
        return gd;
    }

    /**
    * Retrieve the data from a JsonData and create an Item list with the info
    */
    private static List<Item> GetItemFromJsonData(JsonData jsonData) {
        PersistenceType type = PersistenceType.itens;
        Item item = null;
        List<Item> itens = new List<Item>();
        for (int i = 0; i < jsonData[type.ToString()].Count; i++) {
            item = new Item();
            item.id = Convert.ToInt32(jsonData[type.ToString()][i]["id"].ToString());
            item.name = jsonData[type.ToString()][i]["name"].ToString();
            item.description = jsonData[type.ToString()][i]["description"].ToString();
            item.amount = Convert.ToInt32(jsonData[type.ToString()][i]["amount"].ToString());
            item.spritePos = Convert.ToInt32(jsonData[type.ToString()][i]["spritePos"].ToString());
            int x = Convert.ToInt32(jsonData[type.ToString()][i]["coords"][0].ToString());
            int y = Convert.ToInt32(jsonData[type.ToString()][i]["coords"][1].ToString());
            item.coords = new int[] { x, y };
            itens.Add(item);
        }
        return itens;
    }

    /**
    * Generic Load - read athe PersistenceData from the Json file
    */
    public static T LoadObject<T>(PersistenceType type) where T : class {
        //string filePath = Application.persistentDataPath + "/playerInfo.json";
        if (File.Exists(filePath)) {
            try {
                using (Stream stream = File.OpenRead(filePath)) {
                    String jsonString = File.ReadAllText(filePath);
                    JsonData jsonData = JsonMapper.ToObject(jsonString);

                    return jsonData["Item"] as T;
                }
            } catch (Exception e) {
                Debug.Log(e.Message);
            }
        }
        return null;
    }

}
