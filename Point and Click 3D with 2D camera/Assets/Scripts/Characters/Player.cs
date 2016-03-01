using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player : Character {

    public Item itensHeld = null;
	public int lastLevel;

    void OnTriggerEnter(Collider col) {
        //SceneManager.LoadScene(1);
    }

}
