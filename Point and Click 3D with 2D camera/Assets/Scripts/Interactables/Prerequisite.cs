using UnityEngine;
using System.Collections;

public class Prerequisite : MonoBehaviour {
	
    public Switcher watchSwitcher;
    // if true, then block acess 
    public bool nodeAcess;
    // if true, check for item
    //public bool requireItem;
    //if requireItem is true, we'll check this collector
	public ItemController itemController;

    /**
    * Check if prerequisite is met
    */
    public bool Complete {
        get {
			if (watchSwitcher != null) {
                return watchSwitcher.state;

			} else if(itemController != null){
                bool isComplete = false;

				foreach(Item ic in GameManager.gm.invControl.itens){
					isComplete = ic.Equals(itemController.item);
				
					if(isComplete){
						break;
					}
				}
				return isComplete;                
                 // return GameManager.gm.invControl.itens.Contains(checkCollector.item);
			} 
			return false;
        }
    }

}
