using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject inventory;    
    public GameObject player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.I)) {
            ToggleInventory();
        }
	}

    private void ToggleInventory() {
        inventory.SetActive(!inventory.activeInHierarchy);
        inventory.GetComponent<InventoryController>().CreateAndRecreatetInvetory();
        Time.timeScale = !inventory.activeInHierarchy ? 1 : 0;
        DisablePlayer(!inventory.activeInHierarchy);
    }
    private void DisablePlayer(bool flag) {
        player.GetComponent<Player>().enabled = flag;
    }

}
