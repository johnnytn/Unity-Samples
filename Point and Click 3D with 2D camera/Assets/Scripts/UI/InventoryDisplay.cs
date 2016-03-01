using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

	/**
	 * Open the InventoryDisplay showing the name of a item picked 
	 */
    public void UpdateDisplay() {
        this.gameObject.SetActive(true);
        Item item = GameManager.gm.player.itensHeld;
		string displayName = (item != null ) ? item.name : "none";
        GetComponent<Text>().text = "Obtained: " + displayName;
        StartCoroutine(wait());
    }

     /**
     *  Disable display item name after the 2 seconds
     */
    IEnumerator wait() {        
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

}
