using UnityEngine;
using System.Collections.Generic;

public class SettingsController : MonoBehaviour {

    /**
    * Create a PersistenceData with all game data
    */
    private PersistenceData CreatePersistenceData() {
        List<ItemController> itensC = GameManager.gm.invControl.allItens;
        List<Item> itens = new List<Item>();
        foreach (ItemController ic in itensC) {
            itens.Add(ic.item);
        }
        PersistenceData data = new PersistenceData();
        data.itens = itens;

        return data;
    }

    /**
    * Save game data
    */
    public void Save() {
        string filePath = Application.persistentDataPath + "/playerInfo.json";
        JsonPersistence.Save<PersistenceData>(CreatePersistenceData(), filePath);
        Debug.Log("Data saved. ");
    }

    /**
    * Load game data
    */
    public void Load() {
        string filePath = Application.persistentDataPath + "/playerInfo.json";
        PersistenceData data = JsonPersistence.ReadPersistenceData(filePath);
        List<ItemController> itensC = new List<ItemController>();

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
        GameManager.gm.invControl.allItens = itensC;
        GameManager.gm.invControl.CreateAndRecreatetInvetory();
    }

}
