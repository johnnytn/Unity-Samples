using UnityEngine;
using System.Collections;

public class ChangeScene : Interactables {

    public int nextLevel;

    /**
     * Move to the next Scene
     */
    public override void Interact() {
        GameManager.gm.load.LoadingScene(nextLevel);
    }
}
