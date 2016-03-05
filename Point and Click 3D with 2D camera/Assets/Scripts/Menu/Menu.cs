using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    public GameManager gameManager;
    public Loading load;

    /** 
    * Load a level
    */
    public void LoadLevel(int level) {
        load.LoadingScene(level);
       
        // Instantiate the game manager
        GameManager gm = Instantiate(gameManager, new Vector3(0, 0, 0), Quaternion.identity) as GameManager;
        gm.AwakeGM(0);
    }

    /** 
  * Load a level
  */
    public void Continue() {
        PersistenceData data = JsonPersistence.ReadPersistenceData();
        int level = data.gameData != null & data.gameData.currentLevel > 0 ? data.gameData.currentLevel : 1;
        load.LoadingScene(level);
        
        // Instantiate the game manager
        GameManager gm = Instantiate(gameManager, new Vector3(0, 0, 0), Quaternion.identity) as GameManager;
        gm.AwakeGM(level);
    }

    /** 
    * Exit the game
    */
    public virtual void Exit() {
        Application.Quit();
    }

}
