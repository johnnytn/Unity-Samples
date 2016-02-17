using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player : Character {

    public List<Item> itensHeld = null;

    void OnTriggerEnter(Collider col) {
        //SceneManager.LoadScene(1);
    }

}
