using UnityEngine;
using System.Collections;

public class Prerequisite : MonoBehaviour {

    public Switcher watchSwitcher;
    // if true, then block acess 
    public bool nodeAcess;
    // if true, check for item
    public bool requireItem;
    //if requireItem is true, we'll check this collector
    public Collector checkCollector;

    // Check if prerequisite is met
    public bool Complete {
        get {
            if (!requireItem) {
                return watchSwitcher.state;

            } else {
                return GameManager.gm.player.itensHeld.Contains(checkCollector.item);
            }

        }
    }

}
