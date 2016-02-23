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
        bool isActive = inventory.activeInHierarchy;
        inventory.SetActive(!isActive);
        if (!isActive) {
            inventory.GetComponent<InventoryController>().CreateAndRecreatetInvetory();
        } else {
            inventory.GetComponent<InventoryController>().ClearSlots();
        }
        DisablePlayer(!isActive);
    }
    private void DisablePlayer(bool flag) {
        Time.timeScale = flag ? 1 : 0;
        player.GetComponent<Player>().enabled = flag;
    }

}
