using UnityEngine;
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


    public void AwakeGM(int level, bool isNewGame) {
        currentLevel = level;
        PrepareGameManager();
        LoadData(isNewGame);
    }

    void OnLevelWasLoaded(int level) {
        getStartingLocation();
        getPlayer();
        gm.startingNode.Arrive();
    }

    /**
    * Load the Player Data before the game starts:
    * - Load itens;
    * - Create inventory and itens.
    */
    public void LoadData(bool isNewGame) {
        PersistenceData data = JsonPersistence.ReadPersistenceData();
        List<ItemController> itensC = new List<ItemController>();

        if (data != null && !isNewGame) {
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
    * - Search for the player and the starting node.
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

    /**
    * Active or Deactive gameObjects in the UI
    */
    public void ActiveDeactiveGameObjects(bool active) {
        ivCanvas.gameObject.SetActive(active);
        obsCamera.gameObject.SetActive(active);
        invDisp.gameObject.SetActive(active);
        invControl.gameObject.SetActive(active);
    }

}
