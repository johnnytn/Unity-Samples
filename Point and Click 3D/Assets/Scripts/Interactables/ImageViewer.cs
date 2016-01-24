using UnityEngine;
using System.Collections;

public class ImageViewer : Interactables {

    public Sprite pic;

    public override void Interact() {
        GameManager.gm.ivCanvas.Open(pic);
    }
}
