using UnityEngine;
using System.Collections;

public class Prerequisite : MonoBehaviour {

    public Switcher watchSwitcher;
    // if true, then block acess 
    public bool nodeAcess;
    // if true, check for item
    public bool requireItem;
    //if requireItem is true, we'll check this collector
	public Collectable checkCollector;

    /**
    * Check if prerequisite is met
    */
    public bool Complete {
        get {
            if (!requireItem) {
                return watchSwitcher.state;

            } else {
                bool isComplete = false;
				foreach(Item ic in GameManager.gm.invControl.itens){
					isComplete = ic.name.Equals(checkCollector.item.name);
					if(isComplete){
						break;
					}
				}
				return isComplete;                
                 // return GameManager.gm.invControl.itens.Contains(checkCollector.item);
            }

        }
    }

}
