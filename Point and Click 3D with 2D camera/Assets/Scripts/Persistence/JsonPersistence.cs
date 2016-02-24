using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class JsonPersistence {


    public static void Save<T>(List<T> list, string filePath) where T : class {
        //FileStream stream = File.OpenWrite(filePath);
        //File.WriteAllText(filePath, jsonData.ToString());

        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate)) {
            using (StreamWriter writer = new StreamWriter(fs)) {
                //  foreach (T t in list) {
                JsonData jsonData = JsonMapper.ToJson(list);
                writer.Write(jsonData.ToString());
                //   }
                writer.Close();
                writer.Dispose();
            }
            fs.Close();
            fs.Dispose();
        }
    }

    public static T LoadObjects<T>(string filename, PersistenceType type) where T : class {

        if (File.Exists(filename)) {
            try {
                using (Stream stream = File.OpenRead(filename)) {
                    String jsonString = File.ReadAllText(filename);
                    JsonData jsonData = JsonMapper.ToObject(jsonString);

                    T i = GetPersitenceType<T>(jsonData, type) as T;
                    return i as T;
                }
            } catch (Exception e) {
                Debug.Log(e.Message);
            }
        }
        return null;
    }

    private static T GetPersitenceType<T>(JsonData jsonData, PersistenceType type) where T : class {
        T t = null;

        switch (type) {
            case PersistenceType.ITEM:
                {
                    t = GetItemFromJsonData(jsonData, type) as T;
                    break;
                }
        }
        return t as T;
    }

    /**
    * Retrieve the data from a JsonData and create an Item list with the info
    */
    private static Item GetItemFromJsonData(JsonData jsonData, PersistenceType type) {
        Item item = null;
        List<Item> itens = new List<Item>();
        for (int i = 0; i < jsonData[type.ToString()].Count; i++) {
            item = new Item();
            item.id = Convert.ToInt32(jsonData[type.ToString()][1]["id"].ToString());
            item.name = jsonData[type.ToString()][1]["name"].ToString();
            item.description = jsonData[type.ToString()][1]["description"].ToString();
            item.amount = Convert.ToInt32(jsonData[type.ToString()][1]["amount"].ToString());
            item.spritePos = Convert.ToInt32(jsonData[type.ToString()][1]["spritePos"].ToString());
            int x = Convert.ToInt32(jsonData[type.ToString()][1]["coords"][0].ToString());
            int y = Convert.ToInt32(jsonData[type.ToString()][1]["coords"][1].ToString());
            item.coords = new int[] { x, y };
            itens.Add(item);
        }
        Debug.Log(itens.Count);
        return item;
    }



    JsonData GetItem(JsonData jsonData, string type, string name) {

        for (int i = 0; i < jsonData[type].Count; i++) {

            // if(jsonData[type][i]["name"].ToString() == name) {
            return jsonData[type][i];
            // }
        }

        return null;
    }

}
