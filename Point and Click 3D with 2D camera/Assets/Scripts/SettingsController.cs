using UnityEngine;
using System.Collections.Generic;

public class SettingsController : MonoBehaviour {


    public void Save() {
        string filePath = Application.persistentDataPath + "/playerInfo.json";
        List<ItemController> itensC = GameManager.gm.invControl.sortedItens;
        List<Item> itens = new List<Item>();
        foreach (ItemController ic in itensC) {
            itens.Add(ic.item);
        }
        JsonPersistence.Save<Item>(itens, filePath);
        Debug.Log("Data saved. ");
    }

    public void Load() {
        string filePath = Application.persistentDataPath + "/playerInfo.json";
        Item i = JsonPersistence.LoadObjects<Item>(filePath, PersistenceType.ITEM);
        //List<ItemController> itens = GameManager.gm.invControl.sortedItens;
        //itens.Clear();

        Debug.Log(i);
        Debug.Log(i + " - " +
            i.name + " - " +
            i.description + " - " +
            i.type + " - " +
            i.coords[0] + " - -" + i.coords[1]);
        //GameManager.gm.invControl = exampleClass;
    }

}
