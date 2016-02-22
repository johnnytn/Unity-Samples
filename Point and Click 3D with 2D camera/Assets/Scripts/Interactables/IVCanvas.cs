using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IVCanvas : MonoBehaviour {

    public Image imageHolder;

    /**
    * Open canvas image
    */
    public void Open(Sprite pic) {
        ChangeImage(pic, true);
    }

    /**
    * Close canvas image
    */
    public void Close() {
        ChangeImage(null, false);
    }

    /**
    * Change the canvas image
    */
    private void ChangeImage(Sprite pic, bool active) {
        Node currentNote = GameManager.gm.currentNote;
        currentNote.setReachableNode(!active);
        currentNote.col.enabled = !active;
        gameObject.SetActive(active);
        imageHolder.sprite = pic;
    }
}
