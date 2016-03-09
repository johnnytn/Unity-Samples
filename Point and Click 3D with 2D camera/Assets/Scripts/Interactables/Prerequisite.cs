using UnityEngine;
using System.Collections;

public class Prerequisite : MonoBehaviour {
	
    public Switcher watchSwitcher;
    // if true, then block acess 
    public bool nodeAcess;
    // if true, check for item
    //public bool requireItem;
    //if requireItem is true, we'll check this collector
	public Collectable checkCollector;

    /**
    * Check if prerequisite is met
    */
    public bool Complete {
        get {
			if (watchSwitcher != null) {
				Debug.Log("algo -" + watchSwitcher.state);
                return watchSwitcher.state;

			} else if(checkCollector != null){
                bool isComplete = false;
				Debug.Log(GameManager.gm.invControl.itens.Count);

				foreach(Item ic in GameManager.gm.invControl.itens){

					isComplete = ic.name.Equals(checkCollector.item.name);
					Debug.Log("searching for itens");
					Debug.Log(ic.name);
				
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
