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
        PersistenceData data = new PersistenceData();
        data.itens = itens;
        JsonPersistence.Save<PersistenceData>(data, filePath);
        Debug.Log("Data saved. ");
    }

    public void Load() {
        string filePath = Application.persistentDataPath + "/playerInfo.json";
        PersistenceData data = JsonPersistence.LoadPersistenceData(filePath);

        List<ItemController> itensC = new List<ItemController>();
        //List<Item> itens = new List<Item>();

        Debug.Log("Count - 1 -"+data.itens.Count);
        foreach (Item i in data.itens) {
            ItemController ic = gameObject.AddComponent<ItemController>();
            ic.item = i;
            itensC.Add(ic);

            Debug.Log(i);
            Debug.Log(i + " - " +
                i.name + " - " +
                i.description + " - " +
                i.type + " - " +
                i.coords[0] + " - -" + i.coords[1]);
        }
        GameManager.gm.invControl.sortedItens = itensC;
        GameManager.gm.invControl.CreateAndRecreatetInvetory();
        //Debug.Log("Count - 2 -" + GameManager.gm.invControl.sortedItens.Count);

    }

}
