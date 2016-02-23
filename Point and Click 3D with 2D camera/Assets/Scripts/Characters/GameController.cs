using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I)) {
            ToggleInventory();
        }
	}

    public void ToggleInventory() {
        GameObject inventory = GameManager.gm.invControl.gameObject;
        bool isActive = inventory.activeInHierarchy;
        inventory.SetActive(!isActive);     
        DisablePlayer(!isActive);
    }
    private void DisablePlayer(bool flag) {
        Time.timeScale = !flag ? 1 : 0;
       // player.GetComponent<Player>().enabled = flag;
    }

}
