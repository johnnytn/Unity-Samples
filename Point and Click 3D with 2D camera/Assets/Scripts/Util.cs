using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {


    /**
    * Get Player
    */
    public void getPlayer() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player")) {
            GameManager.gm.player = obj.GetComponent<Player>();
        }
    }

    /**
    * Get the Starting Node location
    */
    public void getStartingLocation() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Location")) {
            if (obj.GetComponent<Location>().startingNode) {
                GameManager.gm.startingNode = obj.GetComponent<Location>();
            }
        }
    }
    /**
   * Get the Inventory Display
   */
    protected void getInventoryDisplay() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Inventory Display")) {
            GameManager.gm.invDisp = obj.GetComponent<InventoryDisplay>();
        }
    }

    /**
   * Get the IV Canvas
   */
    protected void getIVCanvas() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("IV Canvas")) {
            GameManager.gm.ivCanvas = obj.GetComponent<IVCanvas>();
        }
    }

    /**
    * Get the Observer Cam
    */
    protected void getObserverCam() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Observer Cam")) {
            GameManager.gm.obsCamera = obj.GetComponent<ObsCamera>();
        }
    }

    /**
    * Get Inventory
    */
    protected void getInventory() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Inventory")) {
            GameManager.gm.invControl = obj.GetComponent<InventoryController>();
        }
    }

    protected IEnumerator wait() {
        //Do whatever you need done here before waiting

        yield return new WaitForSeconds(2f);

        //do stuff after the 2 seconds
    }
}
