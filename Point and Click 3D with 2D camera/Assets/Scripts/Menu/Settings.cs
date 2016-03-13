using System;
using UnityEngine;
using System.Collections.Generic;

public class Settings : Menu {

    /**
    * Create a PersistenceData with all game data
    */
    private PersistenceData CreatePersistenceData() {
        GameManager gm = GameManager.gm;
        List<Item> itens = new List<Item>();
        itens.AddRange(gm.invControl.itens);

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
