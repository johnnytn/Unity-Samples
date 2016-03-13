using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    public GameManager gameManager;
    public Loading load;

    /** 
    * Start a New Game
    */
    public void NewGame() {
        this.LoadLevel(1, true);
    }

    /** 
    * Continue a game
    */
    public void Continue() {
        PersistenceData data = JsonPersistence.ReadPersistenceData();
        int level = data.gameData != null & data.gameData.currentLevel > 0 ? data.gameData.currentLevel : 1;

        this.LoadLevel(level, false);
    }

    /** 
    * Load a level
    */
    private void LoadLevel(int level, bool isNewGame) {
        load.LoadingScene(level);

        // Instantiate the game manager
        GameManager gm = Instantiate(gameManager, new Vector3(0, 0, 0), Quaternion.identity) as GameManager;
        gm.AwakeGM(level, isNewGame);
    }



    /** 
    * Exit the game
    */
    public virtual void Exit() {
        Application.Quit();
    }

}
