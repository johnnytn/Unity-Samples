using UnityEngine;
using System.Collections;

public class ChangeScene : Interactables {

    public int nextLevel;

    public override void Interact() {
        Debug.Log("Next level:" + nextLevel);
        GameManager.gm.load.LoadingScene(nextLevel);
    }
}
