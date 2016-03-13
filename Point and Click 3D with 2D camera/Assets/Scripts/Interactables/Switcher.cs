using UnityEngine;
using System.Collections;

public class Switcher : Interactables {

    public bool state;

    //Event setup
    public delegate void OnStateChange();
    public event OnStateChange Change;

    public override void Interact() {
        base.Interact();
        if (Change != null && interact) {
            state = !state;
            Change();
            return;
        }
    }

}
