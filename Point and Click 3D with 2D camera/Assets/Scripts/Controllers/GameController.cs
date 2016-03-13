using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject backgroundUI;

    // Update is called once per frame
    void Update() {
        CloseInspectors();

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
        backgroundUI.SetActive(!isActive);
    }

    /**
   * Open/close Settings Menu
   */
    public void ToggleSettings() {
        GameObject settings = GameManager.gm.settings;
        bool isActive = settings.activeInHierarchy;
        settings.SetActive(!isActive);
        backgroundUI.SetActive(!isActive);
    }

    private void DisablePlayer(bool flag) {
        Time.timeScale = !flag ? 1 : 0;
        // player.GetComponent<Player>().enabled = flag;
    }

    /**
  * Close UI elements used to inspect objects
  */
    private void CloseInspectors() {
        GameManager gm = GameManager.gm;
        if (Input.GetMouseButtonDown(1) && gm.currentNote != null && gm.currentNote.GetComponent<Prop>() != null) {
            if (gm.ivCanvas.gameObject.activeInHierarchy) {
                gm.ivCanvas.Close();
                return;
            }
            if (gm.obsCamera.gameObject.activeInHierarchy) {
                gm.obsCamera.Close();
                return;
            }
            Location loc = gm.currentNote.GetComponent<Prop>().loc;
            if (loc.cameraPosition != null) {
                loc.Arrive();
            }
        }
    }

}
