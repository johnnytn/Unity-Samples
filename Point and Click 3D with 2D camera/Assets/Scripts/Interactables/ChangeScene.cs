using UnityEngine;
using System.Collections;

public class ChangeScene : Interactables {

    public int nextLevel;
    public Transform child;
    public Animator anim;

    void Awake() {
        child = transform.FindChild("Door_Model");
        anim = child.GetComponent<Animator>();
    }


    /**
     * Move to the next Scene
     * - Plays an animation if exists
     */
    public override void Interact() {
        Prerequisite pre = GetComponent<Prerequisite>();
        if (pre && !pre.Complete) {
            return;
        }
        //anim.Play("OpeningDoor", -1, 0f);        
        anim.SetBool("Open", true);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameManager.gm.currentLevel = nextLevel;
        StartCoroutine(LoadingScene());
    }
    /**
    * Load next scene after a delayed time
    */
    IEnumerator LoadingScene() {
        // Short delay added the next level is loaded
        yield return new WaitForSeconds(1f);
        GameManager.gm.load.LoadingScene(nextLevel);
    }

}
