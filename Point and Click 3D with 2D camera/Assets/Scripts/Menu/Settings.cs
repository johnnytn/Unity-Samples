using UnityEngine;
using System.Collections.Generic;

public class Settings : Menu {

    /**
    * Create a PersistenceData with all game data
    */
    private PersistenceData CreatePersistenceData() {
        GameManager gm = GameManager.gm;
        List<ItemController> itensC = gm.invControl.allItens;
        List<Item> itens = new List<Item>();
        foreach (ItemController ic in itensC) {
            itens.Add(ic.item);
        }
        GameData gameData = new GameData(gm.currentLevel);

        PersistenceData data = new PersistenceData();
        data.itens = itens;
        data.gameData = gameData;

        return data;
    }

    /**
    * Save game data
    */
    public void Save() {        
        JsonPersistence.Save<PersistenceData>(CreatePersistenceData());
        Debug.Log("Data saved. ");
    }

    /**
    * Load game data
    */
    public void Load() {
        Continue();
    }

}
