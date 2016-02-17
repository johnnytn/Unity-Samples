using UnityEngine;
using System.Collections;

public class ChangeScene : Interactables {

    public int nextLevel;

    public override void Interact() {
        Debug.Log("changing level");

        GameManager.gm.load.LoadingScene(nextLevel);
    }
}
