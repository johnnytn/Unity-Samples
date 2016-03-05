using UnityEngine;

[System.Serializable]
public class GameData  {

    public int currentLevel = 1;


    public GameData() {

    }


    public GameData(int currentLevel) {
        this.currentLevel = currentLevel;
    }
}
