using UnityEngine;
using System.Collections;

public class ChangeScene : Interactables {

    public int nextLevel;

    /**
     * Move to the next Scene
     */
    public override void Interact() {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameManager.gm.load.LoadingScene(nextLevel);
		GameManager.gm.player.lastLevel = nextLevel;
    }
}
