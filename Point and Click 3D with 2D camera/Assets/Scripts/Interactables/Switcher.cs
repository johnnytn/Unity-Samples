using UnityEngine;
using System.Collections;

public class Switcher : Interactables {

    public bool state;

    //Event setup
    public delegate void OnStateChange();
    public event OnStateChange Change;

    public override void Interact() {
        state = !state;    
        if(Change != null) {
            Change();
        }
    }

}
