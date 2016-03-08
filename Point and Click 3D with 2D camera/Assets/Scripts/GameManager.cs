﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : Util {

    public static GameManager gm = null;

    [HideInInspector]
    public Node currentNote;
    public Node startingNode;

    public Player player;
    public InventoryDisplay invDisp;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    public Loading load;
    public InventoryController invControl;
    public GameObject settings;

    // Cursor Icon
    public Texture2D interactCursor;
    public Texture2D moveCursor;

    public int currentLevel = 0;

    public void AwakeGM(int level) {
        currentLevel = level;
        PrepareGameManager();
        LoadData();
    }

    void OnLevelWasLoaded(int level) {
        try {
            getStartingLocation();
            getPlayer();
            gm.startingNode.Arrive();
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

    /**
    * Load the Player Data before the game starts
    */
    public void LoadData() {
        PersistenceData data = JsonPersistence.ReadPersistenceData();
        List<ItemController> itensC = new List<ItemController>();

        if (data != null && gm.currentLevel > 0) {
            foreach (Item i in data.itens) {
                ItemController ic = gameObject.AddComponent<ItemController>();
                ic.item = i;
                itensC.Add(ic);
            }
        }
        invControl.allItens = itensC;
        invControl.PrepareInventory();
    }

    /**
    * Prepare GM before the game starts
    */
    public void PrepareGameManager() {
        if (gm == null) {
            gm = this;
        } else if (gm != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        getStartingLocation();
        getPlayer();
    }

    public void ActiveDeactiveGameObjects(bool active) {
        ivCanvas.gameObject.SetActive(active);
        obsCamera.gameObject.SetActive(active);
        invDisp.gameObject.SetActive(active);
        invControl.gameObject.SetActive(active);

    }

}
