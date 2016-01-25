using UnityEngine;
using System.Collections;

public class Switcher : Interactables {

    public bool state;

    //event setup
    public delegate void OnStateChange();
    public event OnStateChange Change;

    public override void Interact() {
        state = !state;
      //  if(GetComponent<StateReactor>()!= null) {
       ///     GetComponent<StateReactor>().React();
      //  }

        if(Change != null) {
            Change();
        }
    }

}
