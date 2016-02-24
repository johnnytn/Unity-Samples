using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class JsonPersistence {

    public static void Save<T>(T data, string filePath) where T : class {

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

    public static T LoadObject<T>(string filename, PersistenceType type) where T : class {

        if (File.Exists(filename)) {
            try {
                using (Stream stream = File.OpenRead(filename)) {
                    //String jsonString = File.ReadAllText(filename);
                    //JsonData jsonData = JsonMapper.ToObject(jsonString);

                    T i = null;//GetPersitenceType<T>(jsonData, type) as T;
                    return i as T;
                }
            } catch (Exception e) {
                Debug.Log(e.Message);
            }
        }
        return null;
    }

    public static PersistenceData LoadPersistenceData(string filename) {

        if (File.Exists(filename)) {
            try {
                using (Stream stream = File.OpenRead(filename)) {
                    String jsonString = File.ReadAllText(filename);
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

    private static PersistenceData GetPersitenceData(JsonData jsonData) {
        PersistenceData data = new PersistenceData();
        Player player = null;
        List<Item> itens = GetItemFromJsonData(jsonData);
        data.itens = new List<Item>();
        data.itens.AddRange(itens);
        data.player = player;

        return data;
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

}
