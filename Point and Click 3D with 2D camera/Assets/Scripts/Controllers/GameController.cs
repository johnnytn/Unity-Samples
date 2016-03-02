using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.I)) {
            ToggleInventory();
        }
	}

    /**
    * Open/close Inventory
    */
    public void ToggleInventory() {
        GameObject inventory = GameManager.gm.invControl.gameObject;
        bool isActive = inventory.activeInHierarchy;
        inventory.SetActive(!isActive);     
        DisablePlayer(!isActive);
    }

    public void ToggleSettings() {
        GameObject settings = GameManager.gm.settings;
        settings.SetActive(!settings.activeInHierarchy);
    }

    private void DisablePlayer(bool flag) {
        Time.timeScale = !flag ? 1 : 0;
       // player.GetComponent<Player>().enabled = flag;
    }

}
